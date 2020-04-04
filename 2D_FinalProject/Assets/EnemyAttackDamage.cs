using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDamage : MonoBehaviour
{

    public float damageSent;

    private PlayerHealth pchealth;
    // Start is called before the first frame update
    void Start()
    {
        pchealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Ecollision)
    {
        if(Ecollision.gameObject.tag == "Enemydamage")
        {
            pchealth.curHealth -= damageSent; 
        }
    }
}
