using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public int weapon = 0;
    /*
        0 = pistol
        1 = machine gun
        2 = knife
        3 = sniper rifle
        4 = grenade launcher
    */
    int maxWeapons = 4;

	public GameObject pistol;
	public GameObject machineGun;
    public GameObject knife;
    public GameObject sniper;
    public GameObject grenadeLauncher;

    float defWeaponTimer;
    float weaponTimer = 0;

    // Use this for initialization
    void Start ()
	{
        defWeaponTimer = Random.Range(5, 15);
    }
	
	// Update is called once per frame
	void Update ()
	{
        weaponTimer += Time.deltaTime;

        if (weaponTimer >= defWeaponTimer)
        {
            defWeaponTimer = Random.Range(5, 15); //changes the timer to something else

            int tempWeapon = Random.Range(0, maxWeapons + 1); //chooses random weapon

            tempWeapon = Mathf.RoundToInt(tempWeapon); //rounds the number 

            //if (tempWeapon == maxWeapons)
            //{
            //    tempWeapon = maxWeapons - 1;
            //}

            weapon = tempWeapon; //sets weapon to the random weapon

            print("weapon changed to " + weapon);

            weaponTimer = 0; //resets timer
        }

		switch (weapon)
		{
            case -1:

                pistol.SetActive(false);
                machineGun.SetActive(false);
                knife.SetActive(false);
                sniper.SetActive(false);
                grenadeLauncher.SetActive(false);
                break;

            case 0:
				pistol.SetActive (true);
				machineGun.SetActive (false);
                knife.SetActive(false);
                sniper.SetActive(false);
                grenadeLauncher.SetActive(false);
                break;

			case 1:
				pistol.SetActive (false);
				machineGun.SetActive (true);
                knife.SetActive(false);
                sniper.SetActive(false);
                grenadeLauncher.SetActive(false);
                break;

            case 2:
                pistol.SetActive(false);
                machineGun.SetActive(false);
                knife.SetActive(true);
                sniper.SetActive(false);
                grenadeLauncher.SetActive(false);
                break;

            case 3:
                pistol.SetActive(false);
                machineGun.SetActive(false);
                knife.SetActive(false);
                sniper.SetActive(true);
                grenadeLauncher.SetActive(false);
                break;

            case 4:
                pistol.SetActive(false);
                machineGun.SetActive(false);
                knife.SetActive(false);
                sniper.SetActive(false);
                grenadeLauncher.SetActive(true);
                break;
        }
	}
}
