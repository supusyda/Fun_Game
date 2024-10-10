using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera camera;
    [SerializeField] ContactFilter2D contactFilter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            List<RaycastHit2D> results = new();

            Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
            float distance = Mathf.Infinity;
            Physics2D.Raycast(mousePos, Vector2.zero, contactFilter, results, distance);
            if (results.Count <= 0) return;
            RaycastHit2D raycastHit2Dhit = results[0];

            if (raycastHit2Dhit == null) return;
            // Debug.Log(raycastHit2Dhit.transform.name + "asdsad");
            IClickAble clickAble = raycastHit2Dhit.collider.GetComponent<IClickAble>();
            if (clickAble != null) clickAble.Click();

        }
    }
}
