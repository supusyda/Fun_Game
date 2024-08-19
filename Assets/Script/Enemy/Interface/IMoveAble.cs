using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAle
{
    // Start is called before the first frame update
    Rigidbody2D RB { get; set; }
    bool IsFacingRight { get; set; }
    float speed { get; set; }
    void MoveEnemy(Vector2 dir);
    void CheckForFaceDir(Vector2 dir);

}
