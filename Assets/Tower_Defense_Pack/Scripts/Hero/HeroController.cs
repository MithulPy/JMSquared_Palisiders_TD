using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls for Hero
//A- Idle Animation
//D- walks when speed >0.1 , runs when speed > 0.7
//Spacebar- Jump
//F- Attack
// Attack and jump return to idle state when false

public class HeroController : MonoBehaviour
{

    Animator anim;
    int isJumping = Animator.StringToHash("isJumping");
    int isAttacking = Animator.StringToHash("isAttacking");




    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();


        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(isJumping);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.ResetTrigger(isJumping);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(isAttacking);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.ResetTrigger(isAttacking);
        }
   
    
    


    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.Translate(Vector2.up * 10f * Time.deltaTime);
        }
    }



}
