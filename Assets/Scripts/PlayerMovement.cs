using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    
    public Vector2 movement;

    public float dashSpeed = 1f;
    public float speed = 0f;

    // Start is called before the first frame update

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * dashSpeed * speed * Time.fixedDeltaTime);
    }
}
