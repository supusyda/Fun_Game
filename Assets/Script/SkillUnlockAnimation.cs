using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SkillUnlockAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool rotate;

    public void Play()
    {

        rotate = false;
        transform.GetComponent<RectTransform>().DOLocalRotate(new Vector3(0, 0, 45), 1, RotateMode.Fast);

    }
}
