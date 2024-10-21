using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SlashEffect", menuName = "Skill/SlashEffect")]
public class SlashOnSwingAbilitySO : AbilitySO
{
    // Start is called before the first frame update
    Transform transform;
    GameObject gameObject;
    public Transform prefab;
    public override void Use(Transform transform)
    {
        var offSetSpawnPosX = .59f;
        Transform spawnOjb = ProjectileSpawner.Instance.SpawnThing(transform.position + new Vector3(offSetSpawnPosX * (PlayerCtr.movement.IsFlip == true ? -1 : 1), 0, 0), transform.rotation, ProjectileSpawner.Instance.SLASH_EFFECT);
        spawnOjb.gameObject.SetActive(true);

    }
    public override void OnBegin()
    {



    }
    public override void Update()
    {

    }
    public override void OnEnd()
    {

    }
    public override void OnUnlock()
    {
        EventDefine.onUnlockOnSwing?.Invoke(this);
    }
}
