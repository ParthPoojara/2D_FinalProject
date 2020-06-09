using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour_PP : MonoBehaviour
{
    #region Public Variables (Variables viewable in the inspector)
    public Transform rayCast; // The location of the raycast
    public LayerMask raycastMask; // The layer which the racast is placed on
    public float rayCastLength; // Length of the raycast
    public float attackDistance; // Minimum attack range
    public float moveSpeed; // The movement speed of the enemy NPC
    public float timer; // Cooldown timer between attacks
    public Transform LeftPatrol;
    public Transform RightPatrol;
    #endregion

    #region Private Variables (Variables not viewable in the inspector)
    private RaycastHit2D hit; // Telling if the raycast hits
    private Transform target; // The enemy's target
    private Animator anim; // Links the animator
    private float distance; // The distance between enemy and player
    private bool attackMode; // Note whether the enemy is attacking or not
    private bool inRange; // See if the player is in range
    private bool cooling; // Sees if the enemy is cooling down after an attack
    private float intTimer; // Sets the initial timer 
    #endregion

    void Awake()
    {
        SelectTarget(); // Calls the select target function
        intTimer = timer; // Stores the initial value of timer
        anim = GetComponent<Animator>(); // Accesses the amimator
    }

    // Update is called once per frame
    void Update()
    {
        // If they player is not in attack more
        if (!attackMode)
        {
            Move();
        }

        //
        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            SelectTarget();
        }

       // If the player is in range
        if (inRange)
        {
            // Checks for a hit with a raycast and stores the information
            hit = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycastMask); // right

            
            // Test the Raycast is working correctly and allows it to be seen
            RaycastDebugger();
        }

        // When the player is detected
        // If the hit collider is not equal to null
        if(hit.collider != null)
        {
            EnemyLogic();
        }
        // If the hit collider is equal to null
        else if(hit.collider == null)
        {
            inRange = false;
        }

        // If the player isn't in range
        if(inRange == false)
        {
            // Triggers the walking animation to false
            //anim.SetBool("canWalk", false);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        // If the object entering the trigger area is tagged player in the inspector then the condition is activated
        if (trig.gameObject.tag == "Player")
        {
            Debug.Log("Player is in trigger");
            target = trig.transform; // The enemy will target the gameObject in the trigger area
            inRange = true; // Indicates the player is in range
            Flip(); // Calls the flip function
        }
    }

    // Once the Gameobject (Player) enters the trigger area
   /* void OnTriggerEnter2D(Collider trig) 
    {
     
    }*/

    // Creating logic for the enemy
    void EnemyLogic()
    {
        // This sets the distance between the player and enemy using the gameObject transform (enemy) and the target (player) transform 
        distance = Vector2.Distance(transform.position, target.position);

        // If the distance is greater than the attack distance the condition is triggered
        if (distance > attackDistance)
        {
            // Activates the move and stop attack function
            
            StopAttack();
        }
        // If the attack distance is greater than or equal to the distance and the cooling is false
        else if (attackDistance >= distance && cooling == false)
        {
            // Activate the attack function
            Attack();
        }

        // If the enemy is cooling down
        if (cooling)
        {
            // Calls the cooldown function
            Cooldown();
            // Sets the attack animation to false
            anim.SetBool("Attack", false);
        }
    }

    // Set the move function
    void Move()
    {
        // Sets the walking animation to true
        anim.SetBool("canWalk", true);
        // Check if it is playing the enemy attack function currently
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            // 
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            // 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        }
    }

    // Set the attack function
    void Attack()
    {
        // Reset the timer when Player enters attack range
        timer = intTimer;
        // To check if the enemy can still attack or not
        attackMode = true;

        // Sets the walking animation to false
        anim.SetBool("canWalk", false);
        // Sets the attack animation to true
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        cooling = false;
        timer = intTimer;
    }

    void StopAttack()
    {
        // Sets cooling to false
        cooling = false;
        // Sets attack mode to false
        attackMode = false;
        // Sets attack animation to false
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        // If the distance between the player and enemy is greater than the attack distance, the condition is triggered
        if (distance > attackDistance)
        {
            // Creates a ray that is visible for us to see in a certain colour
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red); // right
        }
        // If the attack distance is greater than the distance between the enemy and player, the condition is triggered
        else if (attackDistance > distance)
        {
            // Creates a ray that is visible for us to see in a certain colour
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.magenta); // right
        }
        
    }
    // Sets the trigger cooling function
    public void TriggerCooling()
    {
        cooling = true;
    }

    // Check to see if they Enemy NPC is within the boundaries
    private bool InsideofLimits()
    {
        return transform.position.x > LeftPatrol.position.x && transform.position.x < RightPatrol.position.x;
    }
    
    // 
    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, LeftPatrol.position);
        float distanceToRight = Vector2.Distance(transform.position, RightPatrol.position);

        if (distanceToLeft > distanceToRight)
        {
            target = LeftPatrol;
        }
        else
        {
            target = RightPatrol;
        }

        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 0f; //180f;
        }
        else
        {
            rotation.y = 180f; //0f;
        }

        transform.eulerAngles = rotation;
    }
}
