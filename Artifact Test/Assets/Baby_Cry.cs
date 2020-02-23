using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby_Cry : MonoBehaviour
{
    public Transform player;
    public AudioSource baby_cry_source;

    public float dormantVolume = 0.2f, half_Way_Volume = 0.6f, near_Door_Volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Find player
        player = GameObject.Find("Player").GetComponent<Transform>();
        baby_cry_source = this.gameObject.GetComponent<AudioSource>();
        //baby_cry_source.volume = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Distance_Monitor();
    }

    void Distance_Monitor()
    {
        if(Vector3.Distance(transform.position, player.position) >= 3)
        {
            // Lerp sound
            StartCoroutine(Lerp_Volume(baby_cry_source, baby_cry_source.volume, dormantVolume));
        }
        else if (Vector3.Distance(transform.position, player.position) >= 2)
        {
            // Lerp sound
            StartCoroutine(Lerp_Volume(baby_cry_source, baby_cry_source.volume, half_Way_Volume));
        }
        else if (Vector3.Distance(transform.position, player.position) >= 1)
        {
            // Lerp sound
            StartCoroutine(Lerp_Volume(baby_cry_source, baby_cry_source.volume, near_Door_Volume));
        }
    }

    public IEnumerator Lerp_Volume(AudioSource auidioSource, float currentsound, float newvolume)
    {
        auidioSource.volume += Mathf.Lerp(currentsound, newvolume, 1);
        auidioSource.volume = Mathf.Clamp(currentsound, newvolume, 1);
       
        yield break;
    }
}
