using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerhealth;

    private SpriteRenderer sr;
    private ParticleSystem particle;
    private BoxCollider2D bc;


    public float healthbonus = 15f;

    void Awake()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
        particle = GetComponentInChildren<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(playerhealth.curHealth < playerhealth.maxHealth)
        {
            
            playerhealth.curHealth = playerhealth.curHealth + healthbonus;
            StartCoroutine(Break());
        }
    }

    private IEnumerator Break()
    {
        particle.Play();

        sr.enabled = false;
        bc.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);

        Destroy(gameObject);

    }

}
