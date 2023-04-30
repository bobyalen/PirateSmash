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

    public float knockbackForce = 2f;

    public void playerAttack()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackOrgin.position,range,layer);

        if(!damaged)
        {
            foreach(Collider2D enemy in hit)
            {
                if(!enemy.GetComponent<BlockManager>().blocked)
                {
                    Debug.Log("Not blocked attacking: " + enemy.GetComponent<BlockManager>().blocked);
                    enemy.GetComponent<Health>().takeDamage(attackDamage());
                    KnockBack(enemy.GetComponent<Rigidbody2D>(), dmgDirection(enemy.GetComponent<Transform>()));
                    Debug.Log("Direction: " + dmgDirection(enemy.GetComponent<Transform>()));
                    damaged = true;
                }
                else
                {
                    Debug.Log("Blocked: " + enemy.GetComponent<BlockManager>().blocked);
                    enemy.GetComponent<BlockManager>().playerBlock();
                }
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
        return 100;
    }

    public void ResetDamaged()
    {
        damaged= false;
    }

    //Knockback
    #region
    public void KnockBack(Rigidbody2D rb, Vector2 dir)
    {
        rb.AddForce(dir*knockbackForce,ForceMode2D.Impulse);
    }

    Vector2 dmgDirection(Transform other)
    {
        return (other.position - transform.position).normalized;
    }

    #endregion


}
