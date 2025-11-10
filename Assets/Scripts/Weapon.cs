using DitzelGames.FastIK;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool holdingWeapon = false;

    public GameObject[] weaponObjects;

    public bool[] ownedWeapons =
    {
        true, // hands
        false, // dagger
        false // shield
    };

    private int currentWeapon = 0;
    private GameObject currentWeaponObject;

    public FastIKFabric playerHand;
    public GameObject DaggerIK;
    public GameObject ShieldIK;
    public GameObject DaggerPole;
    public GameObject ShieldPole;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon != 0)
            {
                currentWeaponObject.SetActive(false);
            }

            do
            {
                currentWeapon--;
                if (currentWeapon < 0) currentWeapon = ownedWeapons.Length - 1;
            } while (!ownedWeapons[currentWeapon]);

            if (currentWeapon != 0)
            {
                currentWeaponObject = weaponObjects[currentWeapon - 1];
                currentWeaponObject.SetActive(true);
                playerHand.ACTarget = currentWeapon == 1 ? DaggerIK.transform : ShieldIK.transform;
                playerHand.Pole = currentWeapon == 1 ? DaggerPole.transform : ShieldPole.transform;
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeapon != 0)
            {
                currentWeaponObject.SetActive(false);
            }

            do
            {
                currentWeapon++;
                if (currentWeapon >= ownedWeapons.Length) currentWeapon = 0;
            } while (!ownedWeapons[currentWeapon]);

            if (currentWeapon != 0)
            {
                currentWeaponObject = weaponObjects[currentWeapon - 1];
                currentWeaponObject.SetActive(true);
                playerHand.ACTarget = currentWeapon == 1 ? DaggerIK.transform : ShieldIK.transform;
                playerHand.Pole = currentWeapon == 1 ? DaggerPole.transform : ShieldPole.transform;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (other.CompareTag("Dagger")) { ownedWeapons[1] = true; Destroy(other.gameObject); }
            if (other.CompareTag("Shield")) { ownedWeapons[2] = true; Destroy(other.gameObject); }
        }
    }
}
