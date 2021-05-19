using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{
    [SerializeField] private PlayerAnimation animation;
    public float MovementSpeed = 1;
    public float JumpForce = 1;
    public float ClimbingSpeed;
    public bool canMove;
    public bool isLadder;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;

        // Set player position from PersistentData
        // if (!PersistentData.LastPosition) {
            // Debug.Log("found old position");
            // transform.position = PersistentData.LastPosition.position;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
			var movement = Input.GetAxisRaw("Horizontal") * MovementSpeed;
			var Vmovement = Input.GetAxisRaw("Vertical") * ClimbingSpeed;

			transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

			if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
			{
				rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
			}
			if (isLadder == true)
			{
                rb.gravityScale = 0;
                transform.position += new Vector3(0, Vmovement, 0) * Time.deltaTime * ClimbingSpeed;
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
            rb.gravityScale = 1;
        }
    }


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
            Debug.Log("On Ladder");
            isLadder = true;
		}

	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            Debug.Log("Off Ladder");
            isLadder = false;
        }

    }
}