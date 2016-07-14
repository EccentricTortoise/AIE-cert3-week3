using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {

    public float maxHP = 240;
    public float health = 240;
    public Camera cam;
    public Camera miniMap;

    public Light lt;

    bool dmgDisplay = false;

    float lightTimer = 0;
    float invulTimer = 0;

    float invulTime = 0.75f;

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 0;

            lt.intensity = 8;

            //disable scripts
            GetComponent<PlayerControls>().enabled = false;
            GetComponent<PlayerShoot>().enabled = false;
            GetComponent<PlayerCamera>().enabled = false;
            cam.GetComponent<PlayerCamera>().enabled = false;

            miniMap.enabled = false;

            //unfreeze rigidbody and enable gravity
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationX;
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationZ;
            GetComponent<Rigidbody>().useGravity = true;

            //add force to player, making them fall over
            GetComponent<Rigidbody>().AddForce(-transform.right * 50000 * Time.deltaTime);

            //changes colliders so that the player doesnt roll around
            //GetComponent<BoxCollider>().enabled = true;
            //GetComponent<CapsuleCollider>().enabled = false;

            Instantiate(GetComponent<PlayerInteract>().gunToInstantiate, transform.position, transform.rotation); //spawns weapon on ground

            //removes weapon
            GetComponent<PlayerWeapon>().pistol.SetActive(false);
            GetComponent<PlayerWeapon>().machineGun.SetActive(false);
            GetComponent<PlayerWeapon>().knife.SetActive(false);
            GetComponent<PlayerWeapon>().sniper.SetActive(false);
            GetComponent<PlayerWeapon>().grenadeLauncher.SetActive(false);

            GetComponent<PlayerWeapon>().enabled = false;
            GetComponent<PlayerInteract>().enabled = false;
            GetComponent<RestartScript>().enabled = true;

            this.enabled = false; //disables this script
        }

        if (invulTimer > 0)
        {
            invulTimer -= Time.deltaTime;
        }
        else if (invulTimer < 0)
        {
            invulTimer = 0;
        }

        if (dmgDisplay)
        {
            if (lightTimer > 0)
            {
                lightTimer -= Time.deltaTime;

                lt.color = Color.red;
                lt.intensity += Time.deltaTime * 40;
            }

            else if (lightTimer <= 0)
            {
                lightTimer = 0;

                lt.intensity -= Time.deltaTime * 40;

                if (lt.intensity < 1)
                {
                    lt.intensity = 1;
                    lt.color = new Color32(255, 244, 214, 255); //the default yellowish light color
                    dmgDisplay = false;
                }
            }
        }
    }

    public void Damage ()
    {
        if (invulTimer == 0)
        {
            //health -= Random.Range(15, 20);
            invulTimer = invulTime;

            dmgDisplay = true;
            lightTimer = 0.06f;
        }
    }
}
