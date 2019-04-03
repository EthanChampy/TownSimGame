using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float speed = 4;
    float rotspeed = 80;
    float rot = 0f;
    float gravity = 8;
    float useless = 0;

    Vector3 moveDir = Vector3.zero;

    public CharacterController Cont;
    public Animator anim;

    void start()
    {
 
    }

    void Update()
    {
        Movement();
        

    }

    void Movement()
    {
        if (Cont.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        Cont.Move(moveDir * Time.deltaTime);
    }


	
}
