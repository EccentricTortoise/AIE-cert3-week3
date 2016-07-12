using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	public Rigidbody rb;

	float playerSpeed = 100f;
	float speedCap = 125f;
	float playerAccel = 20f;

	float jumpForce = 1200f;
	float gravForce = 75f;

	bool moving = false;

	bool grounded = false;

	//bool fwd = false;
	//bool bwd = false;
	//bool left = false;
	//bool right = false;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Physics.Raycast (transform.position, -transform.up, 2))
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}

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

		if (!grounded)
		{
			rb.velocity -= transform.up * gravForce * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W))
		{
			//transform.position += transform.forward * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity += transform.forward * playerSpeed * Time.deltaTime;

			moving = true;
		}

		if (Input.GetKey (KeyCode.A))
		{
			//transform.position -= transform.right * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity -= transform.right * playerSpeed * Time.deltaTime;

			moving = true;
		}

		if (Input.GetKey (KeyCode.S))
		{
			//transform.position -= transform.forward * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity -= transform.forward * playerSpeed * Time.deltaTime;

			moving = true;
		}

		if (Input.GetKey (KeyCode.D))
		{
			//transform.position += transform.right * playerSpeed * Time.deltaTime; <-- This is the old way of moving
			rb.velocity += transform.right * playerSpeed * Time.deltaTime;

			moving = true;
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (grounded)
			{
				rb.AddForce (transform.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
			}
		}

		if ((!Input.GetKey (KeyCode.W)) && (!Input.GetKey (KeyCode.A)) && (!Input.GetKey (KeyCode.S)) && (!Input.GetKey (KeyCode.D)))
		{
			moving = false;
		}
	}

	void OnGUI()
	{
		GUI.TextField (new Rect (10, 10, 200, 20), "spd " + playerSpeed, 100);
		GUI.TextField (new Rect (10, 31, 200, 22), "grounded " + grounded, 100);
	}
}
