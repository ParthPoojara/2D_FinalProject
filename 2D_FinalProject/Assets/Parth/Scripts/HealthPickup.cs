using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerhealth;

    public float healthbonus = 15f;

    void Awake()
    {
        playerhealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(playerhealth.curHealth < playerhealth.maxHealth)
        {
            Destroy(gameObject);
            playerhealth.curHealth = playerhealth.curHealth + healthbonus;
        }
    }


}
