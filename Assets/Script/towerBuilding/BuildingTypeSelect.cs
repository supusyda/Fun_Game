using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<BuildingSO> buildingSOs = new List<BuildingSO>();
    [SerializeField] Transform buidingTemplate;
    [SerializeField] Dictionary<BuildingSO, Transform> buidingBtnDic;
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
            buidingUI.localScale = new Vector3(1, 1, 1);
            buidingUI.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetSelectedBuilding(item);
                UpdateSelectedBuildingVisual();
                if (BuildingManager.Instance.selectedBuilding == null) return;
                buidingUI.Find("SelectecdBG").gameObject.SetActive(true);
            });
            // buidingUI.Find("SelectecdBG").gameObject.SetActive(false);
            //add to the dictionary buidingBtndic[item] = buidingUI
            buidingBtnDic.Add(item, buidingUI);

        }
        // set all the select back ground to inActive
        UpdateSelectedBuildingVisual();
    }
    public void UpdateSelectedBuildingVisual()
    {

        foreach (BuildingSO buildSO in buidingBtnDic.Keys)
        {
            buidingBtnDic[buildSO].Find("SelectecdBG").gameObject.SetActive(false);
        }
    }

}
