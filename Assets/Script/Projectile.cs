// using System.Collections;
// using System.Collections.Generic;
// using Unity.Mathematics;
// using UnityEngine;

// public class Projectile : MonoBehaviour
// {

//     Transform target;
//     float speed = 10;
//     AnimationCurve trajectoryAnimationCurve;
//     AnimationCurve axisTrajectoryAnimationCurve;
//     Vector3 trajectoryStartPoint;
//     private float trajectoryMaxHight;

//     // Start is called before the first frame update
//     private void Start()
//     {
//         trajectoryStartPoint = transform.position;
//     }
//     private void Update()
//     {
//         if (target == null) return;
//         UpdateProjectilePosition();
//     }
//     void UpdateProjectilePosition()
//     {


//         Vector3 trajectoryRange = target.position - trajectoryStartPoint;
//         float nextPositionX = transform.position.x + speed * Time.deltaTime;
//         float nextPositionXNormalize = (nextPositionX - trajectoryStartPoint.x) / trajectoryRange.x;
//         float nextPositionYNormalize = trajectoryAnimationCurve.Evaluate(nextPositionXNormalize);
//         float nextPositionYNormalizeCorrection = axisTrajectoryAnimationCurve.Evaluate(nextPositionXNormalize);
//         float nextPositionYNormalizeCorrectionA
//         float nextPositionY = trajectoryStartPoint.y +
//             nextPositionYNormalize * trajectoryMaxHight;
//         transform.position = new Vector3(nextPositionX, nextPositionY, 0);


//         // Vector3 moveDir = (target.position - transform.position).normalized;
//         // transform.position += moveDir * speed * Time.deltaTime;

//     }

//     public void Initialization(Transform target, float speed, float trajectoryMaxHight = 10)
//     {
//         this.target = target;
//         this.speed = speed;
//         float xDistance = target.position.x - transform.position.x;

//         this.trajectoryMaxHight = math.abs(xDistance) * trajectoryMaxHight;
//     }
//     public void InitializeProjectilePosition(AnimationCurve trajectoryAnimationCurve, AnimationCurve axisTrajectoryAnimationCurve)
//     {
//         this.trajectoryAnimationCurve = trajectoryAnimationCurve;
//         this.axisTrajectoryAnimationCurve = axisTrajectoryAnimationCurve;
//     }
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         onHitTarget(other.transform);

//     }
//     protected virtual void onHitTarget(Transform target)
//     {
//         if (target.GetComponentInChildren<DamageReciver>() == null) return;
//         DamageReciver damageReciver = target.GetComponentInChildren<DamageReciver>();//Get hit object DamageReciver
//         transform.GetComponentInChildren<DamageDealer>().onHittingEnemy(damageReciver);
//         DestroyMe();
//     }
//     void DestroyMe()
//     {
//         ProjectileSpawner.Instance.DespawnOjb(transform);
//     }

// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private ProjectileVisual projectileVisual;

    private Vector3 target;
    private float moveSpeed;
    private float maxMoveSpeed;
    private float trajectoryMaxRelativeHeight;
    private float distanceToTargetToDestroyProjectile = 1f;

    private AnimationCurve trajectoryAnimationCurve;
    private AnimationCurve axisCorrectionAnimationCurve;
    private AnimationCurve projectileSpeedAnimationCurve;

    private Vector3 trajectoryStartPoint;
    private Vector3 projectileMoveDir;
    private Vector3 trajectoryRange;

    private float nextYTrajectoryPosition;
    private float nextXTrajectoryPosition;
    private float nextPositionYCorrectionAbsolute;
    private float nextPositionXCorrectionAbsolute;

    private void Start()
    {
        trajectoryStartPoint = transform.position;
    }
    protected virtual void onHitTarget(Transform target)
    {
        if (target.GetComponentInChildren<DamageReciver>() == null) return;
        DamageReciver damageReciver = target.GetComponentInChildren<DamageReciver>();//Get hit object DamageReciver
        transform.GetComponentInChildren<DamageDealer>().onHittingEnemy(damageReciver);
        DestroyMe();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        onHitTarget(other.transform);

    }
    void DestroyMe()
    {
        ProjectileSpawner.Instance.DespawnOjb(transform);
    }
    private void Update()
    {

        UpdateProjectilePosition();

        if (Vector3.Distance(transform.position, target) < distanceToTargetToDestroyProjectile)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateProjectilePosition()
    {
        trajectoryRange = target - trajectoryStartPoint;

        if (Mathf.Abs(trajectoryRange.normalized.x) < Mathf.Abs(trajectoryRange.normalized.y))
        {
            // Projectile will be curved on the X axis

            if (trajectoryRange.y < 0)
            {
                // Target is located under shooter
                moveSpeed = -moveSpeed;
            }

            UpdatePositionWithXCurve();

        }
        else
        {
            // Projectile will be curved on the Y axis

            if (trajectoryRange.x < 0)
            {
                // Target is located behind shooter
                moveSpeed = -moveSpeed;
            }

            UpdatePositionWithYCurve();
        }

    }

    private void UpdatePositionWithXCurve()
    {

        float nextPositionY = transform.position.y + moveSpeed * Time.deltaTime;
        float nextPositionYNormalized = (nextPositionY - trajectoryStartPoint.y) / trajectoryRange.y;

        float nextPositionXNormalized = trajectoryAnimationCurve.Evaluate(nextPositionYNormalized);
        nextXTrajectoryPosition = nextPositionXNormalized * trajectoryMaxRelativeHeight;

        float nextPositionXCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionYNormalized);
        nextPositionXCorrectionAbsolute = nextPositionXCorrectionNormalized * trajectoryRange.x;

        if (trajectoryRange.x > 0 && trajectoryRange.y > 0)
        {
            nextXTrajectoryPosition = -nextXTrajectoryPosition;
        }

        if (trajectoryRange.x < 0 && trajectoryRange.y < 0)
        {
            nextXTrajectoryPosition = -nextXTrajectoryPosition;
        }


        float nextPositionX = trajectoryStartPoint.x + nextXTrajectoryPosition + nextPositionXCorrectionAbsolute;

        Vector3 newPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionYNormalized);
        projectileMoveDir = newPosition - transform.position;

        transform.position = newPosition;
    }

    private void UpdatePositionWithYCurve()
    {

        float nextPositionX = transform.position.x + moveSpeed * Time.deltaTime;
        float nextPositionXNormalized = (nextPositionX - trajectoryStartPoint.x) / trajectoryRange.x;

        float nextPositionYNormalized = trajectoryAnimationCurve.Evaluate(nextPositionXNormalized);
        nextYTrajectoryPosition = nextPositionYNormalized * trajectoryMaxRelativeHeight;

        float nextPositionYCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionXNormalized);
        nextPositionYCorrectionAbsolute = nextPositionYCorrectionNormalized * trajectoryRange.y;

        float nextPositionY = trajectoryStartPoint.y + nextYTrajectoryPosition + nextPositionYCorrectionAbsolute;

        Vector3 newPosition = new Vector3(nextPositionX, nextPositionY, 0);

        CalculateNextProjectileSpeed(nextPositionXNormalized);
        projectileMoveDir = newPosition - transform.position;

        transform.position = newPosition;
    }

    private void CalculateNextProjectileSpeed(float nextPositionXNormalized)
    {
        float nextMoveSpeedNormalized = projectileSpeedAnimationCurve.Evaluate(nextPositionXNormalized);

        moveSpeed = nextMoveSpeedNormalized * maxMoveSpeed;
    }

    public void InitializeProjectile(Vector3 target, float maxMoveSpeed, float trajectoryMaxHeight)
    {
        this.target = target;
        this.maxMoveSpeed = maxMoveSpeed;

        float xDistanceToTarget = target.x - transform.position.x;
        this.trajectoryMaxRelativeHeight = Mathf.Abs(xDistanceToTarget) * trajectoryMaxHeight;

        projectileVisual.SetTarget(target);
    }

    public void InitializeAnimationCurves(AnimationCurve trajectoryAnimationCurve, AnimationCurve axisCorrectionAnimationCurve, AnimationCurve projectileSpeedAnimationCurve)
    {
        this.trajectoryAnimationCurve = trajectoryAnimationCurve;
        this.axisCorrectionAnimationCurve = axisCorrectionAnimationCurve;
        this.projectileSpeedAnimationCurve = projectileSpeedAnimationCurve;
    }

    public Vector3 GetProjectileMoveDir()
    {
        return projectileMoveDir;
    }

    public float GetNextYTrajectoryPosition()
    {
        return nextYTrajectoryPosition;
    }

    public float GetNextPositionYCorrectionAbsolute()
    {
        return nextPositionYCorrectionAbsolute;
    }

    public float GetNextXTrajectoryPosition()
    {
        return nextXTrajectoryPosition;
    }

    public float GetNextPositionXCorrectionAbsolute()
    {
        return nextPositionXCorrectionAbsolute;
    }

}
