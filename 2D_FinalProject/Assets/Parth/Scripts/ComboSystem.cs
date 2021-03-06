﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public Animator anime;
    public int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay;

    private mydamage damagescript;

    public GameObject hitbox;
    
    // Start is called before the first frame update
    void Start()
    {
        anime = gameObject.GetComponent<Animator>();

        damagescript = hitbox.GetComponent<mydamage>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if(noOfClicks == 1)
            {
                anime.SetBool("Attack1", true);
            }
            noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }
    }

    public void return1()
    {
        if(noOfClicks >= 2)
        {
            anime.SetBool("Attack2", true);
        }
        else
        {
            anime.SetBool("Attack1", false);
            noOfClicks = 0;
        }
    }


    public void return2()
    {
        if (noOfClicks >= 3)
        {
            anime.SetBool("Attack3", true);
        }
        else
        {
            anime.SetBool("Attack2", false);
            noOfClicks = 0;
        }
    }

    public void return3()
    {
        anime.SetBool("Attack1", false);
        anime.SetBool("Attack2", false);
        anime.SetBool("Attack3", false);

        noOfClicks = 0;
    }

    public void ChangeDmg(int newDmg)
    {
        damagescript.realDamage = newDmg;
    }

}
