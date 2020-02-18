using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour 
{
	[SerializeField]
	Slider healthBar;

	[SerializeField]
	Text healthText;

	[SerializeField]
	GameObject DeathUI;

	Animator myAnimator;

	float maxHealth = 100;
	float curHealth;
	float cooldown = 0;

	public Transform closestenemy;
	public List <Transform> allenemies;
	int aitracker;
	public List<Animator> enemyanimator;

	public static bool isdead;

	// Use this for initialization
	void Start () 
	{
		myAnimator = GetComponent<Animator> ();
		myAnimator.enabled = true;

		healthBar.value = maxHealth;
		curHealth = healthBar.value;

		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			allenemies.Add(go.GetComponent<Transform>());
			enemyanimator.Add(go.GetComponent<Animator>());
		}


	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Saw") 
		{
			healthBar.value -= 1.00f;
			curHealth = healthBar.value;
		}
        else
        if(col.gameObject.tag == "Respawn")
        {
            healthBar.value -= 100f;
            curHealth = healthBar.value;
        }
				
    }


    void Update()
	{
		//new Vector2 distance = this.gameObject.transform.position - 

		healthText.text = curHealth.ToString () + " %";


		if (curHealth <= 0) 
		{
			isdead = true;
			myAnimator.SetBool ("IsDead", isdead);

            Destroy(gameObject, 1f);
		
			DeathUI.gameObject.SetActive (true);


		}

		getclosestenemy(allenemies.ToArray());
		if (animationcontrol)
		{
			cooldown += Time.deltaTime;
		}

		healthBar.value = curHealth;

	}

	
	public Animator closestanim;
	public static bool animationcontrol = false;
	Transform getclosestenemy(Transform[]enemies)
	{
		closestenemy = null;

		float mindist = Mathf.Infinity;
		Vector2 currentpos = this.gameObject.transform.position;
		
		foreach (Transform t in enemies)
		{
			
			float distance = Vector2.Distance(t.position, currentpos);
			if(distance < mindist)
			{
				closestanim = t.gameObject.GetComponent<Animator>();

				closestanim.SetBool("abouttohit", animationcontrol);
				if (animationcontrol)
				{
					
					if(cooldown >= 2f)
					{
						cooldown = 0;
						curHealth -= 20;
					}
				}
				closestenemy = t;
				mindist = distance;
			}
		}
		return closestenemy;
	}

		
}
