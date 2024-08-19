// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class Shooter : MonoBehaviour
// {
//     [SerializeField] Transform shootPoint;
//     [SerializeField] float shootDelay = 1;
//     [SerializeField] float shootDelayTimer = 0;
//     [SerializeField] Transform target;
//     [SerializeField] float arrowSpeed = 10;

//     [SerializeField] float trajectoryMaxHight = 10;
//     [SerializeField] AnimationCurve trajectoryAnimationCurve;
//     [SerializeField] AnimationCurve axisTrajectoryAnimationCurve;
//     [SerializeField]
//     AnimationCurve projectileSpeedAnimationCurve;


//     private void Update()
//     {
//         if (shootDelayTimer <= shootDelay) shootDelayTimer += Time.deltaTime;
//         else Shoot();
//     }
//     void Shoot()
//     {   
//         ResetShootDelayTimer();
//         Transform projectile = ProjectileSpawner.Instance.SpawnThing(shootPoint.position, Quaternion.identity, ProjectileSpawner.Instance.ARROW);
//         projectile.GetComponent<Projectile>().InitializeProjectile(target, arrowSpeed, trajectoryMaxHight);
//         projectile.GetComponent<Projectile>().InitializeAnimationCurves(trajectoryAnimationCurve, axisTrajectoryAnimationCurve, projectileSpeedAnimationCurve);


//         projectile.gameObject.SetActive(true);
//         // Vector3 movingDir = 
//     }
//     void ResetShootDelayTimer()
//     {
//         shootDelayTimer = 0;
//     }

// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform target;

    [SerializeField] private float shootRate;
    [SerializeField] private float projectileMaxMoveSpeed;
    [SerializeField] private float projectileMaxHeight;

    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] private AnimationCurve axisCorrectionAnimationCurve;
    [SerializeField] private AnimationCurve projectileSpeedAnimationCurve;

   

  
    public void BeginShoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.SetActive(true);
        Projectile projectileS = projectile.GetComponent<Projectile>();

        projectileS.InitializeProjectile(target.position, projectileMaxMoveSpeed, projectileMaxHeight);
        projectileS.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
    }
    public void SetTarget(List<Transform> targets)
    {
        if (targets.Count > 0)
        {
            this.target = targets[0];
            return;

        }
        this.target = null;
    }
}