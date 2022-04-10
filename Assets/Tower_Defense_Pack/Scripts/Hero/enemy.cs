using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   public Animator anim;
    public int maxHealth = 100;
    private int currentHealth;
    public float delay = 0f;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth <=0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died!");
        anim.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
       
    }
}