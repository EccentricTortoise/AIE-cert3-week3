using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

	PlayerWeapon playerWeapon;
	public GameObject pistolPrefab;
	public GameObject machineGunPrefab;

    GameObject gunToInstantiate;

	// Use this for initialization
	void Start ()
	{
		playerWeapon = GetComponent<PlayerWeapon> ();
	}

    void SwitchWeapon(RaycastHit hit, int weaponToSwitchTo)
    {
        float dist = Vector3.Distance(hit.collider.gameObject.transform.position, transform.position);

        if (dist < 20)
        {
            playerWeapon.weapon = weaponToSwitchTo;
            Destroy(hit.collider.gameObject);

            Instantiate(gunToInstantiate, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update ()
	{
        switch (playerWeapon.weapon)
        {
            case 0:
                gunToInstantiate = pistolPrefab;
                break;

            case 1:
                gunToInstantiate = machineGunPrefab;
                break;
        }

		if (Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
			
			if (Physics.Raycast(ray, out hit))
			{
                if (hit.collider.gameObject == GameObject.FindGameObjectWithTag("PickupPistol"))
                {
                    SwitchWeapon(hit, 0);
                }

                else if (hit.collider.gameObject == GameObject.FindGameObjectWithTag ("PickupMachineGun"))
				{
                    SwitchWeapon(hit, 1);
                }
			}
		}
	}
}