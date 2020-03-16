using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;

    public bool MoveRight;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        MoveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            
        }
    }
    void OnTriggerEnter2D(Collider2D PatrolPointColl)
    {
        if (PatrolPointColl.gameObject.CompareTag("Patrol"))
        {
            if (MoveRight)
            {
                MoveRight = false;

            }
            else
            {
                MoveRight = true;
            }
        }
    }
}
