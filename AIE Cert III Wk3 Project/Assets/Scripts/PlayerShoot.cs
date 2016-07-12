using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    float timer = 0f;
    float defTimer = 0.25f;

    bool rapidFire = false;

    PlayerWeapon playerWeapon;

	// Use this for initialization
	void Start ()
	{
        playerWeapon = GetComponent<PlayerWeapon>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        switch (playerWeapon.weapon)
        {
            case 0:
                defTimer = 0.25f;
                rapidFire = false;
                break;

            case 1:
                defTimer = 0.05f;
                rapidFire = true;
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
                if (timer >= defTimer)
                {
                    timer = 0;
                    if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f))))
                    {
                        print("you hit a wall");
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (timer >= defTimer)
                {
                    timer = 0;
                    if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f))))
                    {
                        print("you hit a wall");
                    }
                }
            }
        }
	}

    void OnGUI()
    {
        GUI.TextField(new Rect(10, 52, 200, 20), "delay " + timer + " (max is " + defTimer + ")", 100);
        GUI.TextField(new Rect(10, 71, 200, 20), "rapidFire " + rapidFire, 100);
    }
}
