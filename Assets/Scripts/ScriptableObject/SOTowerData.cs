using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Tower Data")]
public class SOTowerData : ScriptableObject
{
    public string Name;
    public int Level;
    public int ShootRange;
    public float ShootInterval;
    public float Damage;
    public int DamageRange;
}
