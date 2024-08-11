using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider healthBar;
    public DamageReciver objectHealth;
    [SerializeField] private float _timeToDrain = 0.25f;
    private float _target;
    private Coroutine drainHealthBarCRT;
    // public GameObject gameObjectHealth;
    private void Start()
    {
        // objectHealth = transform.GetComponentInChildren<DamageAble>();
        healthBar = transform.GetComponent<Slider>();
        healthBar.maxValue = objectHealth.maxHp;
        healthBar.value = objectHealth.maxHp;
        gameObject.SetActive(false);
    }

    public void SetMaxHP()
    {
        healthBar.maxValue = objectHealth.hp;
        healthBar.value = objectHealth.maxHp;
    }
    IEnumerator DrainHealthBar()
    {

        float elapedTime = 0;
        while (elapedTime < _timeToDrain)
        {
            elapedTime += Time.deltaTime;
            healthBar.value = Mathf.Lerp(healthBar.value, _target, elapedTime / _timeToDrain);
            yield return null;
        }
    }
    public void SetHealth(int hp)
    {
        if (gameObject.activeInHierarchy == false) gameObject.SetActive(true);
        _target = hp ;

        StartCoroutine(DrainHealthBar());
    }
}
