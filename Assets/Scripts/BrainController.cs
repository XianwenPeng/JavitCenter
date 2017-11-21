using UnityEngine;
using System.Collections;

public class BrainController : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    void Update()
    {
        if (Input.GetButton("Fire1") )
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
