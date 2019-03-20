﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class e_dialogue : MonoBehaviour
{    
        public string Name;

        [TextArea(3, 10)]
        public string[] sentences;

    public GameObject DiaManager;

    void start()
    {
        DiaManager = GameObject.Find("DialogueManager");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {

            DiaManager.GetComponent<e_dialogueManager>().Invoke("StartDialogue", 0f);
        }
    }
}
