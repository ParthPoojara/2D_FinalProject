using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerHealth : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;

    [SerializeField]
    Text healthText;

    [SerializeField]
    GameObject DeathUI;

    Animator myAnimator;

    public float maxHealth = 100;
    public float curHealth;
    float cooldown = 0;

    public static bool isdead;

    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.enabled = true;

        healthBar.value = maxHealth;
        curHealth = healthBar.value;


    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Saw")
        {
            healthBar.value -= 1.00f;
            curHealth = healthBar.value;
        }
        else
        if (col.gameObject.tag == "Respawn")
        {
            healthBar.value -= 100f;
            curHealth = healthBar.value;
        }
        //else
        // if(col.gameObject.tag == "Health")
        //{
        //	healthBar.value += 50f;
        //	curHealth = healthBar.value;
        //}


    }

    // Sends damage to the PC from the enemy hitbox tagged SwordEnemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SwordEnemy")
        {
            healthBar.value -= 1.00f;
            curHealth = healthBar.value;
        }
    }


    void Update()
    {
        //new Vector2 distance = this.gameObject.transform.position - 

        healthText.text = curHealth.ToString() + " %";


        if (curHealth <= 0)
        {
            isdead = true;
            myAnimator.SetBool("IsDead", isdead);

            Destroy(gameObject, 1f);

            DeathUI.gameObject.SetActive(true);


        }

        healthBar.value = curHealth;

    }
}
