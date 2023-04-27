using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeHandler : MonoBehaviour
{
    [SerializeField]
    Health health;
    [SerializeField]
    Attack dmg;
    bool block;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !block)
        {
            health.takeDamage(dmg.attackDamage());
            Debug.Log("player hit with " + dmg.attackDamage());
        }
    }
}
