using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyFireAfter");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyLife>().TakeDamage(1);
        }
    }

    IEnumerator DestroyFireAfter()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
