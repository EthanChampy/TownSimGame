using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHitbox : MonoBehaviour
{

    public GameObject Player;
    Animator PlayerAnim;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Playar");
        PlayerAnim = Player.GetComponent<Animator>();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Animator>().GetBool("Attacking"))
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
