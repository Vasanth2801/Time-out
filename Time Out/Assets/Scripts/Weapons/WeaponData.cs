using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData",menuName ="Weapons")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int size;
    public float fireRate;
    public int damage;
}