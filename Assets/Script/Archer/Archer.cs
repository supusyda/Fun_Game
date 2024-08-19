using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : AllyBase
{
    // Shooter shooter { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    Shooter shooter { get; set; }
    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    public override void CheckForFaceDir(Vector2 dir)
    {
        base.CheckForFaceDir(dir);
        if (target == null) return;
        // Vector2 dir = target.position - transform.position;
        dir.Normalize();
        if (IsFacingRight && dir.x < 0f)
        {
            Vector3 rotator = new Vector3(0f, 0f, 0f);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && dir.x > 0f)
        {

            Vector3 rotator = new Vector3(0f, 180f, 0f);
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;

        }
    }
   
    // Start is called before the first frame update

}
