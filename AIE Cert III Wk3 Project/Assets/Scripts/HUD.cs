using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Texture crosshair;
    public GameObject player;

    PlayerWeapon playerWeapon;

	// Use this for initialization
	void Start ()
    {
        playerWeapon = player.GetComponent<PlayerWeapon>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI ()
    {
       if (playerWeapon.weapon != 3)
       {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 32, (Screen.height / 2) - 32, 64, 64), crosshair);
       }
    }
}
