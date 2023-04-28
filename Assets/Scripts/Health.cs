using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    bool facingRight;
    [SerializeField]
    int maxHealth;
    [SerializeField]
    int curHealth;
    // Start is called before the first frame update
     Animator animator;
    public HealthBar bar;
    void Start()
    {
        animator = GetComponent<Animator>();
        curHealth= maxHealth;
        bar.SetMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        bar.SetCurHealth(curHealth);
    }

  

    public void takeDamage(int dmg)
    {
        curHealth -= dmg;
        animator.SetTrigger("Hurt");
        Debug.Log("player hit with " + dmg + "New HP: " + curHealth);
        if (curHealth <= 0)
        {
            bar.SetCurHealth(curHealth);
            Die();
        }
    }


    void Die()
    {
        animator.SetTrigger("Die");
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
