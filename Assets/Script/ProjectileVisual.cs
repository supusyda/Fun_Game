using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVisual : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Transform projectileVisual;
    [SerializeField] private Transform projectileShadow;
    [SerializeField] private Projectile projectile;

    private Vector3 target;
    private Vector3 trajectoryStartPosition;

    private float shadowPositionDivider = 6f;

    private void Start() {
        trajectoryStartPosition = transform.position;
    }

    private void Update() {
        UpdateProjectileRotation();
        UpdateShadowPosition();
        
        float trajectoryProgressMagnitude = (transform.position - trajectoryStartPosition).magnitude;
        float trajectoryMagnitude = (target - trajectoryStartPosition).magnitude;

        float trajectoryProgressNormalized = trajectoryProgressMagnitude / trajectoryMagnitude;

        if(trajectoryProgressNormalized < .7f) {
            UpdateProjectileShadowRotation();
        }

    }

    private void UpdateShadowPosition() {
        Vector3 newPosition = transform.position;
        Vector3 trajectoryRange = target - trajectoryStartPosition;

        if(Mathf.Abs(trajectoryRange.normalized.x) < Mathf.Abs(trajectoryRange.normalized.y)) {
            // Projectile is curved on the X axis
            newPosition.x = trajectoryStartPosition.x + projectile.GetNextXTrajectoryPosition() / shadowPositionDivider + projectile.GetNextPositionXCorrectionAbsolute();

        } else {
            // Projectile is curved on the Y axis
            newPosition.y = trajectoryStartPosition.y + projectile.GetNextYTrajectoryPosition() / shadowPositionDivider + projectile.GetNextPositionYCorrectionAbsolute();
        }


        projectileShadow.position = newPosition;
    }

    private void UpdateProjectileRotation() {
        Vector3 projectileMoveDir = projectile.GetProjectileMoveDir();

        projectileVisual.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(projectileMoveDir.y, projectileMoveDir.x) * Mathf.Rad2Deg);
    }

    private void UpdateProjectileShadowRotation() {
        Vector3 projectileMoveDir = projectile.GetProjectileMoveDir();

        projectileShadow.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(projectileMoveDir.y, projectileMoveDir.x) * Mathf.Rad2Deg);
    }

    public void SetTarget(Vector3 target) {
        this.target = target;
    }
}
