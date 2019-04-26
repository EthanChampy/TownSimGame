using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHitbox : MonoBehaviour
{

    public GameObject Player;
    Animator PlayerAnim;
    int Loot;
    int KillCount;


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

        if (KillCount == 10)
        {
            Player.GetComponent<FightingGameTP>().Fighting = false;
            Player.transform.position = new Vector3(30,10,70);
            KillCount = 0;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            KillCount += 1;
            Loot = Random.Range(0,3);
            Debug.Log(Loot);
            Destroy(collision.gameObject);
        }
    }

}
