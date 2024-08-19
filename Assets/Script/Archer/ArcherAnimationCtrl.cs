using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimationCtrl : MonoBehaviour
{
    // Start is called before the first frame update
  public void BeginShoot()
  {
    Shooter shooter = GetComponentInParent<Shooter>();
    shooter.BeginShoot();
  }
}
