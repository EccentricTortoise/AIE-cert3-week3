using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

    float defSpawnTimer = 5;
    float spawnTimer = 0;

    public GameObject cornerA;
    public GameObject cornerB;

    public GameObject enemy;

    int maxEnemies = 25;

	// Use this for initialization
	void Start ()
    {

	}

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length) < maxEnemies) //if the current amount of enemies is less than the maximum amount
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= defSpawnTimer)
            {
                float x = Random.Range(cornerA.transform.position.x, cornerB.transform.position.x);
                float z = Random.Range(cornerA.transform.position.z, cornerB.transform.position.z);

                Instantiate(enemy, new Vector3(x, 4, z), Quaternion.identity);

                print("Enemy spawned at " + " (x: " + x + ", z: " + z + "). " + (GameObject.FindGameObjectsWithTag("Enemy").Length) + " enemies in game.");

                spawnTimer = 0;
            }
        }
    }
}
