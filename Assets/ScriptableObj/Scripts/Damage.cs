using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Damage : ScriptableObject
{
    public enum WeaponKinds
    {
        None = 0,
        Area,
        
    }
    
    public WeaponKinds WeaponKind;
}
