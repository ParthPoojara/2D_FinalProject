using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npcdialoguemanager : MonoBehaviour
{
    public Npcdialogue dialogue;

    Queue<string> sentences;

    public GameObject dialogpanel;

    public TextMeshProUGUI displaytext;

    string activesentence;
    public float tyingspeed;

    AudioSource myaudio;
    public AudioClip speaksound;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        myaudio = GetComponent<AudioSource>();
    }

    void StartDialogue()
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentencelist)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if(sentences.Count <= 0)
        {
            displaytext.text = activesentence;
            return;
        }

        activesentence = sentences.Dequeue();
        displaytext.text = activesentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activesentence));

    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displaytext.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            displaytext.text += letter;
            myaudio.PlayOneShot(speaksound);
            yield return new WaitForSeconds(tyingspeed);
        }
    }
    

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            dialogpanel.SetActive(true);

            StartDialogue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && displaytext.text == activesentence)
            {
                DisplayNextSentence();
            }
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            dialogpanel.SetActive(false);
            StopAllCoroutines();
        }
    }

    
}

