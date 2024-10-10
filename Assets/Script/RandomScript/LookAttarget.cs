using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LookAttarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 dir;
    [SerializeField] float rotationSpeed;
    private EnemyBase _myEnemyBase;
    private void Awake()
    {
        _myEnemyBase = GetComponent<EnemyBase>();
    }
    private void Update()
    {
        // dir = CodeMonkey.Utils.UtilsClass.GetDirToMouse(transform.position);
        SetLookDir(_myEnemyBase.moveDir);
        // Debug.Log(dir);
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // Quaternion rotaion = Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.rotation = Quaternion.Slerp(transform.rotation, rotaion, rotationSpeed * Time.deltaTime);


        Vector3 diff = dir;
        diff = Vector3.Normalize(diff);
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);


        // transform.position = Vector2.MoveTowards(transform.position, CodeMonkey.Utils.UtilsClass.GetMouseWorldPosition(), 1 * Time.deltaTime);
    }
    public void SetLookDir(Vector3 vector3)
    {
        this.dir = vector3;
    }
}
