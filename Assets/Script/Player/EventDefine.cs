
using System.Collections.Generic;
using UnityEngine.Events;

public static class EventDefine
{
    public static UnityEvent<DamageReciver> onTargetInRange = new UnityEvent<DamageReciver>();
    public static UnityEvent<List<AbilitySO>> onAbilityInit = new UnityEvent<List<AbilitySO>>();
    public static UnityEvent<AbilitySO> onAbilityUse = new UnityEvent<AbilitySO>();
    


}