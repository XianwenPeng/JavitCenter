using UnityEngine;
using System.Collections;

public class ZombieWalk : MonoBehaviour {
    public Animator anim;

    Transform wolfie;
    GameObject player;
    NavMeshAgent nav;
    PlayerHealth playerHealth;
    Transform zombie;

    bool died;
	// Use this for initialization
	void Awake () {
        //anim.GetComponent<Animator>();
        wolfie = GameObject.FindGameObjectWithTag("Wolfie_"+1).transform;
        player = GameObject.FindGameObjectWithTag("MainCamera");
        playerHealth = player.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
        
        died = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wolfie_1")
        {
            died = true;
        }
        if (other.tag == "brain")
        {
            died = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wolfie_1")
        {
            died = true;
        }
        if (other.tag == "Brain")
        {
            died = true;
        }
    }
    // Update is called once per frame
    void Update () {
        nav.SetDestination(wolfie.position);
        if (died == true)
        {
            Dead();
        }
        else
        {
            if (playerHealth.currentWolfieLeft > 0)
            {
                nav.SetDestination(wolfie.position);
            }
            else
            {
                nav.enabled = false;
            }
        }
        
	}
    void Dead()
    {
        died = true;
        anim.SetTrigger("Died");
        Destroy(gameObject, 3f);
    }
}
