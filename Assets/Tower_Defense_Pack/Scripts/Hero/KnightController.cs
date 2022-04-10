using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls for Hero
//A- Idle Animation
//D- walks when speed >0.1 , runs when speed > 0.7
//Spacebar- Jump
//F- Attack
// Attack and jump return to idle state when false

public class KnightController : MonoBehaviour
{

    Animator anim;
    public Transform AttackPoint;
    public float attackRange = 1f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public LayerMask enemies;
    int isAttacking = Animator.StringToHash("isAttacking");
 public float speed =0f;



    void Start()
    {
                anim = GetComponent<Animator>();

    }

    void Update()
    {
       
        Movement();


        float move = Input.GetAxis("Horizontal");
               anim.SetFloat("Speed", move);

         if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(isAttacking);

           Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemies);
           foreach(Collider2D enemy in hitEnemies)
           {
               enemy.GetComponent<enemy>().TakeDamage(attackDamage);
           }
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            anim.ResetTrigger(isAttacking);
        }

   void OnDrawGizmosSelected()
   {
       if (AttackPoint == null)
       return;
       Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
   }
    
    


    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
                if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
                if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        
    }



}
