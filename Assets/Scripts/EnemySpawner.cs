using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 0f;
    public int amountOfEnemies = 0;
    public Text enemiesText;

    public GameObject enemyPrefab;

    private void Awake()
    {
        Vector2 spawnPos = transform.position;

        amountOfEnemies = PlayerPrefs.GetInt("enemigos");

        for (int i = 0; i < amountOfEnemies; i++)
        {
            spawnPos = Random.insideUnitCircle.normalized * spawnRadius;
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    private void Update()
    {
        enemiesText.text = "Enemigos: " + amountOfEnemies.ToString();
    }

    public void SubstractAmountEnemies(int amount)
    {
        amountOfEnemies -= amount;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, spawnRadius);
    }
}
