using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentical : MonoBehaviour
{
    // Start is called before the first frame update
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    private Vector3[] segmentVelocity;

    public Transform targetDir;
    public float targetDist;
    public float smoothDampSpeed;
    public float trailSpeed;



    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;



    private void Start()
    {
        lineRenderer.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVelocity = new Vector3[length];
    }
    private void FixedUpdate()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentVelocity[i], smoothDampSpeed + i / trailSpeed);
        }
        lineRenderer.SetPositions(segmentPoses);
    }
}
