using UnityEngine;
using System.Collections;

public class ZombieManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject zombies;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;  
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	void Spawn()
    {
        if(playerHealth.currentWolfieLeft <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(zombies, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
