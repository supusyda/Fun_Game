using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuildingTypeSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<BuildingSO> buildingSOs = new List<BuildingSO>();
    [SerializeField] Transform buidingTemplate;
    [SerializeField] Dictionary<BuildingSO, Transform> buidingBtnDic;
    public static UnityEvent<Skill> onUnlockBuilding = new();
    private void OnEnable()
    {
        onUnlockBuilding.AddListener(ActiveUnlockBuiliding);
    }
    private void Start()
    {
        if (buildingSOs.Count == 0) return;
        buidingBtnDic = new Dictionary<BuildingSO, Transform>();
        foreach (BuildingSO item in buildingSOs)
        {
            //create a btn ui for each building type in canvas
            Transform buidingUI = Instantiate(buidingTemplate, new Vector3(0, 0, 0), Quaternion.identity);
            buidingUI.SetParent(transform);
            //set image for the btn
            buidingUI.Find("Image").GetComponent<Image>().sprite = item.image;
            // make the scale fixed
            buidingUI.localScale = new Vector3(1, 1, 1);
            // add event on btn click
            buidingUI.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetSelectedBuilding(item);
                UpdateSelectedBuildingVisual();
                if (BuildingManager.Instance.selectedBuilding == null) return;
                buidingUI.Find("SelectecdBG").gameObject.SetActive(true);
            });
            buidingUI.gameObject.SetActive(false);
            //add to the dictionary buidingBtndic[item] = buidingUI
            buidingBtnDic.Add(item, buidingUI);

        }
        // set all the select back ground to inActive
        UpdateSelectedBuildingVisual();
    }
    void ActiveUnlockBuiliding(Skill towerID)
    {
        Transform buildingUI = GetBuildingUIBySkill(towerID);
        if (buildingUI == null) return;
        buildingUI.gameObject.SetActive(true);

    }
    Transform GetBuildingUIBySkill(Skill towerID)
    {

        foreach (BuildingSO buildSO in buidingBtnDic.Keys)
        {
            if (buildSO.towerID != towerID) continue;
            return buidingBtnDic[buildSO];
        }
        return null;
    }
    public void UpdateSelectedBuildingVisual()
    {

        foreach (BuildingSO buildSO in buidingBtnDic.Keys)
        {
            buidingBtnDic[buildSO].Find("SelectecdBG").gameObject.SetActive(false);
        }
    }

}
