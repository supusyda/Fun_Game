using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera camera;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D raycastHit2Dhit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (raycastHit2Dhit == null) return;
            // Debug.Log(raycastHit2Dhit.transform + "asdsad");
            IClickAble clickAble = raycastHit2Dhit.collider.GetComponent<IClickAble>();
            if (clickAble != null) clickAble.Click();

        }
    }
}
