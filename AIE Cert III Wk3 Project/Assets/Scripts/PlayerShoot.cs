using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    float timer = 0f;
    float defTimer = 0.25f;
    float mFlashTimer = 0f; //timer for muzzle flash

    bool rapidFire = false;

    PlayerWeapon playerWeapon;

    private GameObject muzzleFlash;
    public GameObject pistolFlash;
    public GameObject machineGunFlash;
    public GameObject sniperFlash;
    public GameObject grenadeLauncherFlash;

    public GameObject grenadeLauncherAmmo;

    float minDmg = 12;
    float maxDmg = 20;

    public Camera mainCam;

    public Texture scopeImage;

	// Use this for initialization
	void Start ()
	{
        playerWeapon = GetComponent<PlayerWeapon>();

        muzzleFlash = pistolFlash;
        muzzleFlash.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (mFlashTimer > 0)
        {
            mFlashTimer -= Time.deltaTime;
        }
        else if (mFlashTimer <= 0)
        {
            mFlashTimer = 0;
            muzzleFlash.SetActive(false);
        }

        switch (playerWeapon.weapon)
        {
            case 0:
                defTimer = 0.25f;
                rapidFire = false;
                muzzleFlash = pistolFlash;
                minDmg = 12;
                maxDmg = 20;
                break;

            case 1:
                defTimer = 0.05f;
                rapidFire = true;
                muzzleFlash = machineGunFlash;
                minDmg = 7;
                maxDmg = 15;
                break;

            case 2:
                defTimer = 0.2f;
                rapidFire = false;
                minDmg = 13;
                maxDmg = 17;
                break;

            case 3:
                defTimer = 1.25f;
                rapidFire = false;
                muzzleFlash = sniperFlash;
                minDmg = 95;
                maxDmg = 100;
                break;

            case 4:
                defTimer = 1.2f;
                rapidFire = false;
                muzzleFlash = grenadeLauncherFlash;
                minDmg = 95;
                maxDmg = 100;
                break;
        }

        timer += Time.deltaTime;

        if (rapidFire)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (playerWeapon.weapon != 4)
                {
                    Shoot();
                }
                else
                {
                    ShootGrenade();
                }
            }
        }

        if (playerWeapon.weapon == 3 && Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = 20;
            GetComponent<PlayerCamera>().sensitivityX = 2.5f;
            mainCam.GetComponent<PlayerCamera>().sensitivityY = 2.5f;
        }
        else
        {
            Camera.main.fieldOfView = 60;
            GetComponent<PlayerCamera>().sensitivityX = 5;
            mainCam.GetComponent<PlayerCamera>().sensitivityY = 5;
        }
	}
    
    void Shoot()
    {
        if (timer >= defTimer)
        {
            timer = 0;

            if (playerWeapon.weapon != 2)
            {
                mFlashTimer = 0.1f;
                muzzleFlash.SetActive(true);
            }

            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));

            if (playerWeapon.weapon != 2)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        hit.collider.gameObject.GetComponent<DamageEnemy>().Damage(minDmg, maxDmg);
                    }

                    if (hit.collider.gameObject.tag == "DeadEnemy")
                    {
                        Vector3 dir = hit.collider.transform.position - transform.position;
                        dir.Normalize();

                        hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(dir * 15);
                    }
                }
            }
            else
            {
                if (Physics.Raycast(ray, out hit, 4f))
                {
                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        print("stab stab");
                        hit.collider.gameObject.GetComponent<DamageEnemy>().Damage(minDmg, maxDmg);
                    }
                }
            }
        }
    }

    void ShootGrenade()
    {
        if (timer >= defTimer)
        {
            timer = 0;

            mFlashTimer = 0.1f;
            muzzleFlash.SetActive(true);

            Instantiate(grenadeLauncherAmmo, muzzleFlash.transform.position, Quaternion.Euler(new Vector3(-75, 0, 0)));
        }
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 52, 200, 20), "delay " + timer + " (max is " + defTimer + ")", 100);
        GUI.TextField(new Rect(10, 71, 200, 20), "rapidFire " + rapidFire, 100);

        if (playerWeapon.weapon == 3 && Input.GetMouseButton(1))
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), scopeImage);
        }
    }
}
