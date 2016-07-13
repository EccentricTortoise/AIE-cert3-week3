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
                break;

            case 1:
                defTimer = 0.05f;
                rapidFire = true;
                muzzleFlash = machineGunFlash;
                break;

            case 2:
                defTimer = 0.2f;
                rapidFire = false;
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
                Shoot();
            }
        }
	}
    
    void Shoot()
    {
        if (timer >= defTimer)
        {
            timer = 0;

            mFlashTimer = 0.1f;
            muzzleFlash.SetActive(true);

            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f))))
            {
                print("you hit a wall");
            }
        }
    }

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 52, 200, 20), "delay " + timer + " (max is " + defTimer + ")", 100);
        GUI.TextField(new Rect(10, 71, 200, 20), "rapidFire " + rapidFire, 100);
    }
}
