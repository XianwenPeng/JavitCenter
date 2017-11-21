using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {
    public int startingWolfieLeft = 3;
    public int currentWolfieLeft;
    public Text wolfieLeftString;
    public float flashSpeed = 5;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    // Use this for initialization

    Animator anim;
    FirstPersonController playerMovement;
    bool isDead;
    bool damaged;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentWolfieLeft = startingWolfieLeft;
        playerMovement = GetComponent<FirstPersonController>();
    }
    void Update()
    {
        if (damaged)
        {
            wolfieLeftString.color = flashColor;
        }
        else
        {
            wolfieLeftString.color = Color.Lerp(wolfieLeftString.color, Color.clear, flashSpeed*Time.deltaTime);
        }
    }
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentWolfieLeft -= amount;
        wolfieLeftString.text = "Wolfies Left: " + currentWolfieLeft;
        if(currentWolfieLeft <= 0 && !isDead)
        {
            Death();
        }

    }
    void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.enabled = false;
        //playerShooting.enabled = false;
        
    }

   
}
