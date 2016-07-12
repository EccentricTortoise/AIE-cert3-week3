using UnityEngine;
using System.Collections;

public class LockCursor : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown (KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
	}
}
