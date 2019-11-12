using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour 
{
	[SerializeField]
	Slider healthBar;

	[SerializeField]
	Text healthText;

	[SerializeField]
	//GameObject DeathUI;

	Animator myAnimator;

	float maxHealth = 100;
	float curHealth;


	// Use this for initialization
	void Start () 
	{
		myAnimator = GetComponent<Animator> ();
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
	}

	void Update()
	{
		healthText.text = curHealth.ToString () + " %";

		if (curHealth <= 0) 
		{
			myAnimator.SetBool ("IsDead", true);
            Destroy(gameObject, 3f);
		
			//DeathUI.gameObject.SetActive (true);
		}

	
	}
		
}
