using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    Health health;
    [SerializeField]
    public float attackDelay = 0.3f;
    public Transform attackOrgin;
    public float range = 0.5f;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerAttack()
    {
        Debug.Log("swinging");
        Collider2D[] hit = Physics2D.OverlapCircleAll(attackOrgin.position,range,layer);

        foreach(Collider2D enemy in hit)
        {
            int dmg = attackDamage();
            health.takeDamage(dmg);
        }

        StartCoroutine(DelayAttack());
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrgin == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackOrgin.position, range);
    }

private IEnumerator DelayAttack()
{
    yield return new WaitForSeconds(attackDelay);
}
public int attackDamage()
    {
        return 2;
    }

}
