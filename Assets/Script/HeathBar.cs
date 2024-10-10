using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private float _timeToDrain = 0.25f;
    public DamageReciver objectHealth;
    private float _target;
    public Slider healthBar;
    public RectTransform holder;
    [SerializeField] public TMP_Text hpText;
    private Image fillImage;
    private void OnEnable()
    {

        healthBar = transform.GetComponent<Slider>();
        fillImage = healthBar.fillRect.GetComponent<Image>();
        SetHPbarToMaxHP((int)objectHealth.maxHp);
        // holder.gameObject.SetActive(false);

    }

    public void SetHPbarToMaxHP(int maxHP)
    {
        healthBar.maxValue = maxHP;
        healthBar.value = maxHP;
        SetHPText(maxHP, maxHP);


    }
    IEnumerator DrainHealthBar()
    {

        float elapedTime = 0;
        float newValue;
        while (elapedTime < _timeToDrain)
        {
            elapedTime += Time.deltaTime;
            newValue = Mathf.Lerp(healthBar.value, _target, elapedTime / _timeToDrain);
            healthBar.value = newValue;

            fillImage.color = Color.Lerp(fillImage.color, new Color(fillImage.color.r, (healthBar.value / healthBar.maxValue) - 0.1f, fillImage.color.b, 1), elapedTime / _timeToDrain);
            SetHPText((int)newValue, (int)objectHealth.maxHp);
            yield return null;
        }
    }
    public void SetHealth(int hp)
    {
        // show health bar when being hit

        if (holder.gameObject.activeInHierarchy == false)
        {
            holder.gameObject.SetActive(true);

        };
        _target = hp;
        StartCoroutine(DrainHealthBar());
    }
    void SetHPText(int hp, int maxHP)
    {
        if (hpText == null) return;
        hpText.text = hp + " / " + maxHP;
    }
}
