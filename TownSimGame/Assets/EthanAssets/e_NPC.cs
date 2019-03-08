using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_NPC : MonoBehaviour {

    public e_dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<e_dialogueManager>().StartDialogue(dialogue);
    }
}
