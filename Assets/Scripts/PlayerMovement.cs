using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private Vector2 mousePos;


    // Abilities
    public GameManager gameManager;
    public int ch2Amount;
    public int ch3Amount;
    public int ch4Amount;
    public bool isVAbilityActive;
    public bool isBAbilityActive;
    // Destroy 90%
    public GameObject enemySpawner;
    public int ninetyPercent;
    public int nAbilityUses, valor90;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public Collider2D[] enemiesToDamage;

    public Vector2 movement;

    public float dashSpeed = 1f;
    public float speed = 0f;
    public Camera cam;

    // Start is called before the first frame update

    private void Awake()
    {
        isVAbilityActive = false;
        isBAbilityActive = false;
        nAbilityUses = 0;
        ch2Amount = PlayerPrefs.GetInt("ch2");
        ch3Amount = PlayerPrefs.GetInt("ch3");
        ch4Amount = PlayerPrefs.GetInt("ch4");
        Application.targetFrameRate = 60;
        
    }

    void Start()
    {
        valor90 = PlayerPrefs.GetInt("valor90");
        ninetyPercent = enemySpawner.GetComponent<EnemySpawner>().NinetyPercent();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
        enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);

        if (Input.GetKeyDown(KeyCode.V) && !isVAbilityActive && ch2Amount > 0)
        {
            isVAbilityActive = true;
            isBAbilityActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.V) && isVAbilityActive && ch2Amount >= 0)
        {
            isVAbilityActive = false;
        }
        
        if (Input.GetKeyDown(KeyCode.B) && !isBAbilityActive && ch3Amount > 0)
        {
            isBAbilityActive = true;
            isVAbilityActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.B) && isBAbilityActive && ch3Amount >= 0)
        {
            isBAbilityActive = false;
        }

        if (Input.GetKeyDown(KeyCode.N) && ch4Amount > 0 && nAbilityUses < 1)
        {
            try
            {
                for (int i = 0; i < ninetyPercent; i++)
                {
                    Destroy(enemiesToDamage[i].gameObject);
                }
                enemySpawner.GetComponent<EnemySpawner>().SubstractAmountEnemies(ninetyPercent);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            nAbilityUses += 1;
            ch4Amount -= 1;
            PlayerPrefs.SetInt("ch4", ch4Amount);
            valor90 = valor90 * 2;
            PlayerPrefs.SetInt("valor90", valor90);
            PlayerPrefs.Save();
        }

        if (isVAbilityActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (ch2Amount > 0)
                {
                    ch2Amount -= 1;
                    Debug.Log("Shooting");
                    GetComponent<Shooting>().ShootShuriken();
                    PlayerPrefs.SetInt("ch2", ch2Amount);
                    Debug.Log(ch2Amount);
                }
                else
                {
                    isVAbilityActive = false;
                    Debug.Log("Ch2 Acabo");
                }
                
            }
        }
        
        if (isBAbilityActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (ch3Amount > 0)
                {
                    ch3Amount -= 1;
                    Debug.Log("Shooting Fire");
                    GetComponent<Shooting>().ShootFire();
                    PlayerPrefs.SetInt("ch3", ch3Amount);
                    Debug.Log(ch3Amount);
                }
                else
                {
                    isBAbilityActive = false;
                    Debug.Log("Ch3 Acabo");
                }
                
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * dashSpeed * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
