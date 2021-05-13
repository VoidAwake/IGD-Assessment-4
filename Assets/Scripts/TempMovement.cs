using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimation animation;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public bool canMove;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
		{
            var movement = Input.GetAxisRaw("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }

            if (Math.Abs(movement) != 0) {
                if (movement > 0) {
                    animation.WalkAnimation("right");
                } else {
                    animation.WalkAnimation("left");
                }
            } else {
                animation.IdleAnimation();
            }
        }
    }
}
