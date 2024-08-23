using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    [SerializeField] float range = 3;
    public void setAnimationCurl()
    {

    }
    override public void BeginShoot()
    {

        Vector3 dir = CodeMonkey.Utils.UtilsClass.GetDirToMouse(transform.position);
        float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Transform projecttile = ProjectileSpawner.Instance.SpawnThing(transform.position, Quaternion.identity, ProjectileSpawner.Instance.SLASH);

        projecttile.gameObject.SetActive(true);
        projecttile.GetComponent<Fly>().SetRotationAndDir(Quaternion.Euler(0f, 0f, rot_z), dir);




    }
}
