using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiaMovement : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public int SecondJump = 1;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {    
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.W) && Grounded && SecondJump >= 0)
        {
            Jump();
            SecondJump--;

            if (SecondJump == 0)
            {
                Grounded = false;
            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Tierra")) 
        {
            Grounded = true;

            SecondJump = 2;

        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);
    }
}
