using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

    public float health = 80;
    public Camera cam;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            health = 0;

            //disable scripts
            GetComponent<PlayerControls>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;
            GetComponent<PlayerCamera>().enabled = false;
            GetComponent<PlayerInteract>().enabled = false;
            cam.GetComponent<PlayerCamera>().enabled = false;

            //unfreeze rigidbody and enable gravity
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationZ;
            GetComponent<Rigidbody>().useGravity = true;

            //add force to player, making them fall over
            GetComponent<Rigidbody>().AddForce(-transform.right * 12000 * Time.deltaTime);

            //changes colliders so that the player doesnt roll around
            //GetComponent<BoxCollider>().enabled = true;
            //GetComponent<CapsuleCollider>().enabled = false;

            Instantiate(GetComponent<PlayerInteract>().gunToInstantiate, transform.position, transform.rotation); //spawns weapon on ground

            GetComponent<PlayerWeapon>().weapon = -1; //removes weapon

            this.enabled = false; //disables this script
        }
    }

    public void Damage ()
    {
        health -= Random.Range(15, 20);
        print("player hp " + health);
    }
}
