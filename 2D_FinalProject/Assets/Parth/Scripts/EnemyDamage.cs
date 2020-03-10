using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health;
    private mydamage damagescript;
    public GameObject hitbox;
    private Animator animer;

    public Material whitemat;
    public Material normalmat;
    public SpriteRenderer[] parts;

    // Start is called before the first frame update
    void Start()
    {
        damagescript = hitbox.GetComponent<mydamage>();
        animer = gameObject.GetComponent<Animator>();
    }

  
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == hitbox.tag)
        {
            health -= damagescript.realDamage;
            animer.SetTrigger("gethit");
            
        }
       

        if(health <= 0)
        {
           Destroy(gameObject);
        }

    }
    
    public void flashwhite()
    {
        for(int i =0; i <= parts.Length -1; i++)
        {
            parts[i].material = whitemat;
        }
    }

    public void flashwnormal()
    {
        for (int i = 0; i <= parts.Length - 1; i++)
        {
            parts[i].material = normalmat;
        }
    }
}
