using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class DangerZone : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LineRenderer lineRenderer;
    private float waveValue = 10;
    private void Awake() {
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }
   public void SetPos( Vector3 pos)
    {
        lineRenderer.positionCount = 2;
        Vector3[] positions = new[] { transform.parent.position, pos };
        lineRenderer.SetPositions(positions);
    }
   public void ClearPos()
    {
        lineRenderer.positionCount = 0;
    }
}
