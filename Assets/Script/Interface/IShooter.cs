using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter
{
    protected Shooter shooter { get; set; }
    protected void SetShooter(Shooter shooter);


}
