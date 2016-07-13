using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

    float health = 100;

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

    public void Damage ()
    {
        health -= Random.Range(12, 20);
        print(health);
    }
}
