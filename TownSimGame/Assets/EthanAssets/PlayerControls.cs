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

    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        if (Cont.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (anim.GetBool("Attacking") == true)
                {
                    return;
                }
                else if (anim.GetBool("Attacking") == false)
                {
                    anim.SetBool("Running", true);
                    anim.SetInteger("Condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("Running", false);
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }
        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        Cont.Move(moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if (Cont.isGrounded)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (anim.GetBool("Running") == true)
                {
                    anim.SetBool("Running", false);
                    anim.SetInteger("Condition", 0);
                }
                if(anim.GetBool("Running") == false)
                {
                    Attacking();
                }
            }
        }
    }

    void Attacking()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        anim.SetBool("Attacking", true);
        anim.SetInteger("Condition", 2);
        yield return new WaitForSeconds(1);
        anim.SetInteger("Condition", 0);
        anim.SetBool("Attacking", false);
    }
	
}
