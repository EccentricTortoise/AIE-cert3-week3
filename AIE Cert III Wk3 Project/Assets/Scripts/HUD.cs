using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Texture crosshair;
    public Texture hpBarBG;
    public Texture hpBar;
    public Material hpBarMat;
    public GameObject player;

    float maxHP;
    float hp;
    float fillAmount;

    PlayerWeapon playerWeapon;

	// Use this for initialization
	void Start ()
    {
        playerWeapon = player.GetComponent<PlayerWeapon>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        maxHP = player.GetComponent<DamagePlayer>().maxHP;
        hp = player.GetComponent<DamagePlayer>().health;

        fillAmount = hp / maxHP;
	}

    void OnGUI ()
    {
        //Graphics.DrawTexture(new Rect(20, 20, 300, 45), hpBarBG, hpBarMat);
        //Graphics.DrawTexture(new Rect(20, 20, 300 * fillAmount, 45), hpBar, hpBarMat);

       GUI.DrawTexture(new Rect(20, 20, 300, 45), hpBarBG);
       GUI.DrawTexture(new Rect(20, 20, 300 * fillAmount, 45), hpBar);

        if (playerWeapon.weapon != 3)
       {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 32, (Screen.height / 2) - 32, 64, 64), crosshair);
       }
    }
}
