using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    private EnemySpawner enemySpawner;
    public SoundScript soundScript;
    public AudioClip audioClip;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        soundScript = FindObjectOfType<SoundScript>();
        life = 1;
    }

    private void Update()
    {
        if (life <= 0)
            Die();
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log("Damage Taken");
    }

    void Die()
    {
        soundScript.playSound(audioClip);
        enemySpawner.SubstractAmountEnemies(1);
        Destroy(gameObject);

    }
}
