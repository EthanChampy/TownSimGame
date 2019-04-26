using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingGameTP : MonoBehaviour {

    public bool Fighting = false;
    public GameObject Zombie;
    public GameObject ZombieSpawner;
    public GameObject Player;
    public float SpawnTime;

	// Use this for initialization
	void Start ()
    {
        ZombieSpawner = GameObject.Find("ZombieSpawner");
        Player = GameObject.Find("Playar");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SpawnTime <= 0)
        {
            if (Fighting == true)
            {
                Instantiate(Zombie, new Vector3(55.09f, 10f, (80.16f + Random.Range(-3,3))), Quaternion.identity);
            }
            SpawnTime = Random.Range(6f, 8f);
        }

        SpawnTime += -Time.deltaTime;

        if (Fighting == true)
        {
            SpawnTime += -Time.deltaTime;
        }
	}

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "FightingEnter" && Input.GetKeyDown(KeyCode.E) && Fighting == false)
        {
            Fighting = true;
            Player.transform.position = new Vector3(36, 11, 80);
        }
    }
}
