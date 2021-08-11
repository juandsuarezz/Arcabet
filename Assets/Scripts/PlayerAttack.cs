using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Attack");
        }
    }

    IEnumerator Attack()
    {
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("attack", false);
    }
}
