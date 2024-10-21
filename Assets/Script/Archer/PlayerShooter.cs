using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{

    public void setAnimationCurl()
    {

    }
    override public void BeginShoot()
    {

        Vector3 dir = CodeMonkey.Utils.UtilsClass.GetDirToMouse(transform.position);
        Vector3 mousePos = CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition();
        // target.position = mousePos;
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.SetActive(true);
        Projectile projectileS = projectile.GetComponent<Projectile>();
        projectileS.InitializeProjectile(mousePos, projectileMaxMoveSpeed, projectileMaxHeight);
        projectileS.InitializeAnimationCurves(trajectoryAnimationCurve, axisCorrectionAnimationCurve, projectileSpeedAnimationCurve);
        // float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Transform projecttile = ProjectileSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ProjectileSpawner.Instance.SLASH);

        // projecttile.gameObject.SetActive(true);
        // projecttile.GetComponent<NormalProjectile>().SetRotationAndDir(Quaternion.Euler(0f, 0f, rot_z), dir);





    }
}
