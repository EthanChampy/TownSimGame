using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWalk : MonoBehaviour {

    public GameObject Player;
    public int speed = 4;


    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Playar");
	}
	
	// Update is called once per frame
	void Update ()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        transform.LookAt(Player.transform);
    }
}
