using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    Health health;
    public Transform attackOrgin;
    public float range = 0.5f;
    public LayerMask layer;
    RaycastHit2D[] hit;
    bool damaged;

    public void playerAttack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackOrgin.position,range,layer);

        if(!damaged)
        {
            foreach(Collider2D enemy in hit)
            {
                enemy.GetComponent<Health>().takeDamage(attackDamage());
                damaged = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrgin == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackOrgin.position, range);
    }
    public int attackDamage()
    {
        return 2;
    }

    public void ResetDamaged()
    {
        damaged= false;
    }
}
