using UnityEngine;
using System.Collections;

public class WolfieDance : MonoBehaviour {
    Animator anim;
    bool died;
	// Use this for initialization
	//void Start () {
	
	//}
    void Awake()
    {
        anim.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (died)
        {
            Dead();
        }
        else
        {
            Dancing(died);
        }
        

    }
    void Dancing(bool dead)
    {
        if(dead == false)
        {
            anim.SetBool("ZombieDied", false);
        }
    }
    void Dead()
    {
        died = true;
        anim.SetBool("ZombieDied", true);
        Destroy(gameObject, 2f);
    }

    
}
