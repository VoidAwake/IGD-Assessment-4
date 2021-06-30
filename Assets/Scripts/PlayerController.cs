using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAnimation animation;
    public float movementSpeed = 1;
    public bool isDoor;

    [HideInInspector] public DialogueManager DM;
    public GameObject Player;

    public bool canMove = true;

    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            switch (PersistentData.PreviousScene)
            {
                case 0:
                    transform.position = new Vector3(-4.2f, 0f, 0.1f);
                    break;
                case 1:
                    transform.position = new Vector3(-3.25f, -0.3f, 0.1f);
                    break;
                case 2:
                    transform.position = new Vector3(-1.85f, -0.3f, 0.1f);
                    break;
                case 3:
                    transform.position = new Vector3(-0.45f, -0.3f, 0.1f);
                    break;
                case 4:
                    transform.position = new Vector3(1.05f, -0.3f, 0.1f);
                    break;
                case 5:
                    transform.position = new Vector3(2.45f, -0.3f, 0.1f);
                    break;
                case 8:
                    transform.position = new Vector3(3.2f, -0.3f, 0.1f);
                    break;
                default:
                    transform.position = new Vector3(-4.2f, 0f, 0.1f);
                    break;
            }
        }

        DM = FindObjectOfType<DialogueManager>();

        // Set player position from PersistentData
        // if (!PersistentData.LastPosition) {
        // Debug.Log("found old position");
        // transform.position = PersistentData.LastPosition.position;
        // }
    }

    void Update()
    {
        if (!canMove)
            return;
        
        if (!DM.isInteracting)
        {
            var movement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
            
            transform.Translate(movement, 0, 0);
            
            Player.GetComponent<ContextClue>().enabled = !isDoor;

            if (Math.Abs(movement) != 0)
            {
                animation.WalkAnimation(movement > 0 ? "right" : "left");
            }
            else
            {
                animation.IdleAnimation();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            isDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            isDoor = false;
        }
    }
}