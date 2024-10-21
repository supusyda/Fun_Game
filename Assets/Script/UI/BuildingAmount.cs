using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BuildingAmount : MonoBehaviour
{
    // Start is called before the first frame update
    public static UnityEvent<int, int> onBuildingAmountChange = new();
    [SerializeField] TMP_Text current;
    [SerializeField] TMP_Text max;
    private void OnEnable()
    {
        onBuildingAmountChange.AddListener(UpdateBuildingAmount);
    }
    void OnDisable()
    {
        onBuildingAmountChange.RemoveListener(UpdateBuildingAmount);
    }
    private void UpdateBuildingAmount(int current, int max)
    {
        Debug.Log("UPDATE BUIlDING");
        this.current.text = current.ToString();
        this.max.text = max.ToString();
    }


}
