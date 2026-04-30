using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // gets the mouse position
        mousePos.z = 0f;

        Vector2 direction = mousePos - transform.position; 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector3 scale = transform.localScale;  // making sure the scale is to what we set in unity
        float originalX = Mathf.Abs(scale.x);
        float originalY = Mathf.Abs(scale.y);

        if (angle > 90 || angle < -90) // makes sure that the player isnt upside down
        {
            scale.x = originalX; 
            scale.y = -originalY;
        }
        else
        {
            scale.x = originalX;
            scale.y = originalY;
        }

        transform.localScale = scale;
    }
}