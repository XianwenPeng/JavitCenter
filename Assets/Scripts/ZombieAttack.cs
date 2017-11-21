using UnityEngine;
using System.Collections;

public class ZombieAttack : MonoBehaviour {
    public float timeBetweenAttack = 0.5f;
    public int attackDamage = 10;
    // Use this for initialization
    Animator anim;
    GameObject wolfie;
    PlayerHealth playerHealth;
    //ZombieHealth zombieHealth;
    bool playerInRange;
    float timer;

    void Awake()
    {
        wolfie = GameObject.FindGameObjectWithTag("Wolfie_1");
        playerHealth = wolfie.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == wolfie)
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == wolfie)
        {
            playerInRange = false;
        }
    }
    
	void Update () {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttack && playerInRange) {
            Attack();
        }
        if (playerHealth.currentWolfieLeft <= 0)
        {
            anim.SetTrigger("ZombieDied");
        }
            
	}
    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentWolfieLeft > 0)
        {
            playerHealth.TakeDamage(1);
        }
    }
}
