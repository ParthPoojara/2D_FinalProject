using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Npcdialogue 
{
    public string nameofperson;

    [TextArea(3, 10)]
    public string[] sentencelist;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
