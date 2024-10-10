
using System.Collections.Generic;
using UnityEngine.Events;

public static class EventDefine
{
    public static UnityEvent<DamageReciver> onTargetInRange = new UnityEvent<DamageReciver>();
    public static UnityEvent<List<AbilitySO>> onAbilityInit = new UnityEvent<List<AbilitySO>>();
    public static UnityEvent<Ability> onAbilityInit2 = new UnityEvent<Ability>();

    public static UnityEvent<AbilitySO> onAbilityUse = new UnityEvent<AbilitySO>();

    public static UnityEvent OnClickOnPlayer = new();


    public static UnityEvent<AbilityHolder> abiHolderRef = new();
    public static UnityEvent<float, float> ShakeCamera = new();
    private static UnityEvent onEnemyDie = new();
    public static UnityEvent OnEnemyDie { get => onEnemyDie; }

}