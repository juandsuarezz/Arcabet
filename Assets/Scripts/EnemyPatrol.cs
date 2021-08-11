using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float x;
    public float y;
    public float direction_time;

    private float initialTime;
    private Rigidbody2D enemyRb;
    private Vector2 movement;

    private void Start()
    {
        initialTime = direction_time;
        enemyRb = GetComponent<Rigidbody2D>();
        RandomPos();
    }

    private void Update()
    {
        movement.x = x;
        movement.y = y;

        enemyRb.MovePosition(enemyRb.position + movement * speed * Time.deltaTime);
        direction_time -= Time.deltaTime;

        if (direction_time <= 0)
        {
            RandomPos();
            direction_time = initialTime;
        }
    }

    void RandomPos()
    {
        x = Random.Range(-1, 2);
        y = Random.Range(-1, 2);
    }

}
