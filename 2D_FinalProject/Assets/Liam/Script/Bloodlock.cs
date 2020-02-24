using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodlock : MonoBehaviour
{

    public GameObject[] GOcollectibles;
    public GameObject TriggeredObject;
    public bool enabled;
        
        // Start is called before the first frame update
    void Start()
    {
        // Disables the target object
        if (enabled) TriggeredObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // number of objects started with
        int ObjectsLeft = GOcollectibles.Length;

        // loop through activation objects
        foreach (GameObject GO in GOcollectibles)
        {
            //Take away an object when destoryed
            if (!GO) ObjectsLeft--;
        }

        // There are no objects left
        if (ObjectsLeft < 1)
        {
            // Enabling and disabling objects
            if (enabled)
                TriggeredObject.SetActive(true);
            else
                TriggeredObject.SetActive(false);
        }
    }
}
