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

    public RectTransform holder;
    [SerializeField] public TMP_Text hpText;
    [SerializeField] private Image fillImage;
    private Color originalColor;
    void Awake()
    {
        originalColor = fillImage.color;
    }
    private void OnEnable()
    {


        SetHPbarToMaxHP((int)objectHealth.maxHp);

        fillImage.color = originalColor;
        // holder.gameObject.SetActive(false);

    }

    public void SetHPbarToMaxHP(int maxHP)
    {
        fillImage.fillAmount = 1;
        // fillImage.value = maxHP;
        SetHPText(maxHP, maxHP);


    }
    IEnumerator DrainHealthBar()
    {

        float elapedTime = 0;
        float newValue;
        while (elapedTime < _timeToDrain)
        {
            elapedTime += Time.deltaTime;
            newValue = Mathf.Lerp(fillImage.fillAmount, _target, elapedTime / _timeToDrain);
            fillImage.fillAmount = newValue;

            fillImage.color = Color.Lerp(fillImage.color, new Color(fillImage.color.r, (fillImage.fillAmount / fillImage.fillAmount) - 0.1f, fillImage.color.b, 1), elapedTime / _timeToDrain);
            SetHPText((int)(newValue * objectHealth.maxHp), (int)objectHealth.maxHp);
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
        _target = hp / objectHealth.maxHp;
        StartCoroutine(DrainHealthBar());
    }
    void SetHPText(int hp, int maxHP)
    {
        if (hpText == null) return;
        hpText.text = hp + " / " + maxHP;
    }
}
