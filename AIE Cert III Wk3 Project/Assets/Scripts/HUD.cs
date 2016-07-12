using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public Texture crosshair;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI ()
    {
        GUI.DrawTexture(new Rect((Screen.width / 2) - 64, (Screen.height / 2) - 64, 64, 64), crosshair);
    }
}
