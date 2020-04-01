using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoremanager2 : MonoBehaviour
{
    public static Scoremanager2 instance2;
    public TextMeshProUGUI text2;

    int score2;

    void Start()
    {
        if (instance2 == null)
        {
            instance2 = this;
        }
    }

    public void ChangeScore2(int coinValue2)
    {
        score2 += coinValue2;
        text2.text = "" + score2.ToString();
    }
}
