using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float bulletForce = 20f;

    [Header("References")]
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private Transform firePoint;

    [Header("Weapons Settings")]
    public WeaponData[] weapons;
    public int currentWeaponIndex = 0;
    WeaponData currentWeapon;
    int currentMag;
    float nextTimeToFire;
    int[] ammoCount;

    [SerializeField] private TextMeshProUGUI weaponText;

    void Start()
    {
        ammoCount = new int[weapons.Length];
        for(int i=0;i<weapons.Length; i++)
        {
            ammoCount[i] = weapons[i].size;
        }

        EquipWeapon(0);
    }

    void EquipWeapon(int index)
    {
        if(index < 0 || index >= weapons.Length)
        {
            return;
        }

        currentWeaponIndex = index;
        currentWeapon = weapons[index];
        currentMag = ammoCount[index];

        Debug.Log("Equipped" + currentWeapon.weaponName);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(2);
        }

        UpdateUI();
    }

    void Shoot()
    {
        if(Time.time < nextTimeToFire)
        {
            return;
        }
        if (currentMag > 0)
        {
            GameObject bullet = pooler.SpawnFromPools("B", firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
            currentMag--;
            ammoCount[currentWeaponIndex] = currentMag;
            nextTimeToFire = Time.time + 1f / currentWeapon.fireRate;
        }
        else
        {
            Debug.Log("Out of Ammo for " + currentWeapon.weaponName);
        }
    }

    void UpdateUI()
    {
        weaponText.text = "Weapon: " + currentWeapon.weaponName;
    }
}