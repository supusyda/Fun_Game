using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera cinemachineVirtualCamera;
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    [SerializeField] float shakeTime;
    bool _isShake;
    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void OnEnable()
    {
        EventDefine.ShakeCamera.AddListener((time, intensity) =>
        {
            ShakeCamera(time, intensity);
        });
    }
    private void OnDisable()
    {
        EventDefine.ShakeCamera.RemoveAllListeners();
    }
    void ShakeCamera(float timeShake, float instentsity)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = instentsity;
        shakeTime = timeShake;
        _isShake = false;
        StartCoroutine(BeginShake());
    }
    IEnumerator BeginShake()
    {
        yield return new WaitForSeconds(shakeTime);//lerp the instent to 0
        float elapedTime = 0;
        float newValue;
        float _timeToDrain = .5f;
        while (elapedTime < _timeToDrain)
        {
            elapedTime += Time.deltaTime;
            newValue = Mathf.Lerp(cinemachineBasicMultiChannelPerlin.m_AmplitudeGain, 0, elapedTime / _timeToDrain);
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = newValue;

            yield return null;
        }

    }
}
