using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	public Rigidbody rb;

	float playerSpeed = 100f;
	float speedCap = 125f;
	float playerAccel = 20f;
	float playerFrict = 1.5f;

	bool moving = false;

	bool fwd = false;
	bool bwd = false;
	bool left = false;
	bool right = false;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (moving)
		{
			playerSpeed += playerAccel;

			if (playerSpeed > speedCap)
			{
				playerSpeed = speedCap;
			}
		}
		else
		{
			playerSpeed -= playerAccel;

			if (playerSpeed <= 0)
			{
				playerSpeed = 0;
			}
		}

		if (Input.GetKey (KeyCode.W))
		{
			//transform.position += transform.forward * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity += transform.forward * playerSpeed * Time.deltaTime;

			fwd = true;
			moving = true;
		}

		if (Input.GetKey (KeyCode.A))
		{
			//transform.position -= transform.right * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity -= transform.right * playerSpeed * Time.deltaTime;

			left = true;
			moving = true;
		}

		if (Input.GetKey (KeyCode.S))
		{
			//transform.position -= transform.forward * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity -= transform.forward * playerSpeed * Time.deltaTime;

			bwd = true;
			moving = true;
		}

		if (Input.GetKey (KeyCode.D))
		{
			//transform.position += transform.right * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity += transform.right * playerSpeed * Time.deltaTime;

			right = true;
			moving = true;
		}

		if ((!Input.GetKey (KeyCode.W)) && (!Input.GetKey (KeyCode.A)) && (!Input.GetKey (KeyCode.S)) && (!Input.GetKey (KeyCode.D)))
		{
			moving = false;
		}
	}

	void OnGUI()
	{
		GUI.TextField (new Rect (10, 10, 200, 20), "spd " + playerSpeed, 100);
	}
}
