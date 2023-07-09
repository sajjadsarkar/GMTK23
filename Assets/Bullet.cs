using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletSpeedAuto = 10f;
    public float destroyDelay = 10f;
    public int scoreValue = 10;

    private bool canMove = true;
    private bool isDestroyed = false;

    private Rigidbody rb;
    public float minX = -10f; // Minimum X coordinate limit
    public float maxX = 10f;  // Maximum X coordinate limit
    public float minY = -10f; // Minimum Y coordinate limit
    public float maxY = 10f;  // Maximum Y coordinate limit
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        /*        Destroy(gameObject, destroyDelay);*/
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            transform.Translate(Vector3.left * bulletSpeedAuto * Time.deltaTime);
            // Get input for bullet movement
            float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right keys
            float moveY = Input.GetAxis("Vertical");   // W/S or Up/Down keys

            // Calculate the target position based on the input
            Vector3 targetPosition = transform.position + new Vector3(moveX, moveY, 0) * bulletSpeed * Time.deltaTime;

            // Clamp the target position within the specified limits
            float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, 0);

            // Move the bullet to the clamped position
            rb.MovePosition(clampedPosition);

            // Set bullet velocity based on input
            Vector3 movement = new Vector3(moveX, moveY, 0);
            rb.velocity = movement.normalized * bulletSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isDestroyed)
        {
            // Increase score and destroy enemy
            GameManager.Instance.AddScore(scoreValue);
            Destroy(other.gameObject);

            // Prevent bullet from hitting multiple enemies
            isDestroyed = true;
            rb.velocity = Vector3.zero;

            // Destroy bullet after hitting an enemy
            Destroy(gameObject, 0.1f);
        }
    }

    public void StopMovement()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
    }
}

