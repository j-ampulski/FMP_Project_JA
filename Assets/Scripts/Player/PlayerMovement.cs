using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // how quick the player will move

    private Rigidbody2D rb; // getting the players rigidbody
    private Vector2 movement; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // sets the rb to the players rigidbody so the player moves
    }

    void Update()
    {
 
        movement.x = Input.GetAxisRaw("Horizontal"); // Gets horizontal movement from the keyboard and sets movement to horizontal
        movement.y = Input.GetAxisRaw("Vertical"); // Gets horizontal movement from the keyboard and sets movement to vertical

        movement = movement.normalized;
    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);  // moves the player in the direction the player has  pressed
    }
}