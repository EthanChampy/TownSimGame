using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    public int TreeValue;

    public GameObject Stump;

	// Use this for initialization
	void Start ()
    {
        TreeValue = Random.Range(3, 10);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (TreeValue <= 0)
        {
            Instantiate(Stump, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
	}
}
