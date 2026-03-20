using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        // FIXED flipping (no scaling issues)
        Vector3 scale = transform.localScale;
        float originalX = Mathf.Abs(scale.x);
        float originalY = Mathf.Abs(scale.y);

        if (angle > 90 || angle < -90)
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