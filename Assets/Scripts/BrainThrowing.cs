using UnityEngine;
using System.Collections;

public class BrainThrowing : MonoBehaviour {

    public GameObject player;
    public float speed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");

        GetComponent<Rigidbody>().velocity = player.transform.forward * speed;
    }
}
