using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attacktimer = 0;
    private float attackcool = 0.3f;

    public Collider2D attacktrigger;

    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attacktrigger.enabled = false; 
    }

    void Update()
    {
        if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attacktimer = attackcool;
            attacktrigger.enabled = true;
        }
       
        if (attacking)
        {
            if(attacktimer > 0)
            {
                attacktimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attacktrigger.enabled = false;
            }
        }
        anim.SetBool("IsAttacking", attacking);
        

    }


}
