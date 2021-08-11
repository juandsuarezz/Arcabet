using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 0f;
    public int amountOfEnemies = 0;

    public GameObject enemyPrefab;

    private void Awake()
    {
        Vector2 spawnPos = transform.position;

        for (int i = 0; i < amountOfEnemies; i++)
        {
            spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, spawnRadius);
    }
}
