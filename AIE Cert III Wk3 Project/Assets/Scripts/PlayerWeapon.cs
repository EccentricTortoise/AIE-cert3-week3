using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public int weapon = 0;
    /*
        0 = pistol
        1 = machine gun
    */

	public GameObject pistol;
	public GameObject machineGun;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (weapon)
		{
			case 0:
				pistol.SetActive (true);
				machineGun.SetActive (false);
				break;

			case 1:
				pistol.SetActive (false);
				machineGun.SetActive (true);
				break;
		}
	}
}
