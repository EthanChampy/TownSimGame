using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class e_dialogueManager : MonoBehaviour
{

    public GameObject Player;
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Playar");
        sentences = new Queue<string>();
    }


    public void StartDialogue(e_dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        Player.gameObject.GetComponent<PlayerControls>().speed = 0;
        Player.gameObject.GetComponent<PlayerControls>().rotspeed = 0;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Player.gameObject.GetComponent<PlayerControls>().speed = 4;
        Player.gameObject.GetComponent<PlayerControls>().rotspeed = 140;
        animator.SetBool("IsOpen", false);
    }
}
