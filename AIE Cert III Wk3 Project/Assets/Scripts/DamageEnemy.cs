using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

    float health = 60;

    public Transform player;

    public GameObject deadEnemy;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            health = 0;

            Instantiate(deadEnemy, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
	}

    public void Damage (float min, float max)
    {
        health -= Random.Range(min, max);
    }
}
