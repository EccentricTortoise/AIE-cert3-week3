using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public int weapon = 0;
    /*
        0 = pistol
        1 = machine gun
        2 = knife
    */

	public GameObject pistol;
	public GameObject machineGun;
    public GameObject knife;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (weapon)
		{
            case -1:
                pistol.SetActive(false);
                machineGun.SetActive(false);
                knife.SetActive(false);
                break;

            case 0:
				pistol.SetActive (true);
				machineGun.SetActive (false);
                knife.SetActive(false);
                break;

			case 1:
				pistol.SetActive (false);
				machineGun.SetActive (true);
                knife.SetActive(false);
                break;

            case 2:
                pistol.SetActive(false);
                machineGun.SetActive(false);
                knife.SetActive(true);
                break;
		}
	}
}
