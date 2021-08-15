using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine("DestroyShurikenAfter");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyLife>().TakeDamage(1);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyShurikenAfter()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
