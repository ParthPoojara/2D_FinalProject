using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health;
    private mydamage damagescript;
    public GameObject hitbox;
    // Start is called before the first frame update
    void Start()
    {
        damagescript = hitbox.GetComponent<mydamage>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == hitbox.tag)
        {
            health -= damagescript.realDamage;
        }
    }

}
