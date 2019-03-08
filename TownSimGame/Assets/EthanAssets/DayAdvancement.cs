using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAdvancement : MonoBehaviour {

    public bool GoalsComplete = false;
    public int DayNumber = 1;

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "DayAdvancer" && Input.GetKeyDown(KeyCode.E) && GoalsComplete == true)
        {
            DayNumber += 1;
            GoalsComplete = false;
        }
    }
}
