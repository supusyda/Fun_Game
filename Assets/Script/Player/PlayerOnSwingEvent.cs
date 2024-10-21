using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnSwingEvent : MonoBehaviour
{
    // Start is called before the first frame update
    List<AbilitySO> _unlockedOnSlashSkill = new List<AbilitySO>();
    void OnEnable()
    {
        EventDefine.onUnlockOnSwing.AddListener(OnUnlockOnSlashKill);
    }
    void OnDisable()
    {
        EventDefine.onUnlockOnSwing.RemoveListener(OnUnlockOnSlashKill);
    }
    public void SpawnSlash()
    {
        _unlockedOnSlashSkill.ForEach(skill =>
        {
            skill.Use(transform);
        });
        // var offSetSpawnPosX = .59f;
        // Transform spawnOjb = ProjectileSpawner.Instance.SpawnThing(transform.position + new Vector3(offSetSpawnPosX * (PlayerCtr.movement.IsFlip == true ? -1 : 1), 0, 0), transform.rotation, ProjectileSpawner.Instance.SLASH_EFFECT);
        // spawnOjb.gameObject.SetActive(true);
    }
    public void PlaySlashSound()
    {
        AudioManager.Instance.PlayAudio(AudioManager.Instance._SLASH_SFX);
    }
    private void OnUnlockOnSlashKill(AbilitySO abilitySO)
    {
        _unlockedOnSlashSkill.Add(abilitySO);
        Debug.Log(abilitySO.name);
    }
}
