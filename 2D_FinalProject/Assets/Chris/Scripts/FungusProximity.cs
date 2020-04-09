using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusProximity: MonoBehaviour
{
    public GameObject GO_thePlayer;

    public float fl_minTriggerDistance;

    public string st_fungusMessage = "TestMessage";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector2.Distance(this.transform.position, GO_thePlayer.transform.position);
     
        if (currentDistance <= fl_minTriggerDistance)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                Fungus.Flowchart.BroadcastFungusMessage(st_fungusMessage);
            }
        }
    }
}
