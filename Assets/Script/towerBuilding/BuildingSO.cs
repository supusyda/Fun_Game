using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="Building", menuName = "Building")]
public class BuildingSO : ScriptableObject
{
    // Start is called before the first frame update
    public Transform prefab;
    public Sprite image;
    public int price;
    public Skill towerID;
}
