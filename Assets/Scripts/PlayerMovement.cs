using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private Vector2 mousePos;


    // Abilities
    public int ch2Amount;
    public int ch3Amount;
    public int ch4Amount;
    public bool isVAbilityActive;
    public bool isBAbilityActive;
    public int nAbilityUses;


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
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

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
            nAbilityUses += 1;
            // Dissappear the 90% of the enemies;
        }

        if (isVAbilityActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (ch2Amount > 0)
                    ch2Amount -= 1;
                else
                {
                    isVAbilityActive = false;
                    Debug.Log("Ch2 Acabo");
                }
                Debug.Log("Shooting");
                PlayerPrefs.SetInt("ch2", ch2Amount);
                Debug.Log(ch2Amount);
            }
        }
        
        if (isBAbilityActive)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (ch3Amount > 0)
                    ch3Amount -= 1;
                else
                {
                    isBAbilityActive = false;
                    Debug.Log("Ch3 Acabo");
                }
                Debug.Log("Shooting Fire");
                Debug.Log(ch3Amount);
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
}
