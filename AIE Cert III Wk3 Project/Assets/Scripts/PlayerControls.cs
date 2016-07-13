using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	public Rigidbody rb;

	float playerSpeed = 100f;
	float speedCap = 85f;
	float playerAccel = 20f;

	float jumpForce = 1200f;
	float gravForce = 95f;

	bool moving = false;

	bool grounded = false;
    bool climbing = false;

	//bool fwd = false;
	//bool bwd = false;
	//bool left = false;
	//bool right = false;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Ladder")
        {
            climbing = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Ladder")
        {
            climbing = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (Physics.Raycast (transform.position, -transform.up, 1.5f))
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

        if (!grounded && !climbing)
		{
			rb.velocity -= transform.up * gravForce * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.W))
		{
            if (!climbing)
            {
                rb.velocity += transform.forward * playerSpeed * Time.deltaTime;
            }
			else
            {
                rb.velocity += transform.up * (playerSpeed / 1.5f) * Time.deltaTime;
            }

			moving = true;
		}

		if (Input.GetKey (KeyCode.A))
		{
			rb.velocity -= transform.right * playerSpeed * Time.deltaTime;

			moving = true;
		}

		if (Input.GetKey (KeyCode.S))
		{
            if (!climbing)
            {
                rb.velocity -= transform.forward * playerSpeed * Time.deltaTime;
            }
            else
            {
                rb.velocity -= transform.up * (playerSpeed / 1.5f) * Time.deltaTime;
            }

            moving = true;
		}

		if (Input.GetKey (KeyCode.D))
		{
			rb.velocity += transform.right * playerSpeed * Time.deltaTime;

			moving = true;
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (grounded)
			{
                rb.velocity += transform.up * jumpForce * Time.deltaTime;
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
        GUI.TextField (new Rect (210, 10, 200, 22), "climbing " + climbing, 100);
	}
}
