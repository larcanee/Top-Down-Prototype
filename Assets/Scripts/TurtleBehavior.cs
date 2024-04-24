using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleBehavior : MonoBehaviour
{   
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;
    private Vector3 movement;

    // Define the bounds
    private float minY = -7.9f;
    private float maxY = 4f;
    private float minX = -9.17f;
    private float maxX = 8.95f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Input handling
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.z = 0;
        movement = movement.normalized; // Normalize the movement vector to ensure constant speed diagonally

        // Move the character
        Vector3 newPosition = transform.position + (movement * speed * Time.deltaTime);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); // Clamp the x position
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY); // Clamp the y position
        transform.position = newPosition;

        // Update character sprite based on movement direction
        if (movement.x > 0)
        {
            // Move right
            SetSpriteDirection("Right");
        }
        else if (movement.x < 0)
        {
            // Move left
            SetSpriteDirection("Left");
        }
        else if (movement.y > 0)
        {
            // Move up
            SetSpriteDirection("Up");
        }
        else if (movement.y < 0)
        {
            // Move down
            SetSpriteDirection("Down");
        }
    }

    // Function to change the character sprite based on movement direction
    void SetSpriteDirection(string direction)
    {
        // Load and assign the appropriate sprite image for the given direction
        Sprite sprite = Resources.Load<Sprite>("Sprites/" + direction); // Assuming sprite images are stored in a "Sprites" folder
        spriteRenderer.sprite = sprite;
    }
}
