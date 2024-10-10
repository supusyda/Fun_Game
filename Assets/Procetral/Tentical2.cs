using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentical2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int length;
    public LineRenderer lineRenderer;
    public Vector3[] segmentPoses;
    private Vector3[] segmentVelocity;

    public Transform targetDir;
    public float targetDist;
    public float smoothDampSpeed;




    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;
    public List<Transform> bodyPart = new List<Transform>();
    public Transform tail;



    private void Start()
    {
        lineRenderer.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentVelocity = new Vector3[length];
        ResetPos();
    }
    private void FixedUpdate()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentVelocity[i], smoothDampSpeed);
            bodyPart[i - 1].transform.position = segmentPoses[i];
        }
        lineRenderer.SetPositions(segmentPoses);
        // tail.position = segmentPoses[bodyPart.Count - 1];
    }
    void ResetPos()
    {
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;

        }
        lineRenderer.SetPositions(segmentPoses);
    }
}
