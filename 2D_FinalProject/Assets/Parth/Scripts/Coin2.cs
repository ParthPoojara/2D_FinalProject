using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : MonoBehaviour
{
    public int coinValue2 = 5;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Scoremanager2.instance2.ChangeScore2(coinValue2);

        }
    }

}
