using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 10f;

    private Vector3 targetPosition;

    void Start()
    {
        // Set the initial target position within the movement limits
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the object has reached the target position
        if (transform.position == targetPosition)
        {
            // Set a new random target position
            targetPosition = GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        // Generate random x and z coordinates within the movement limits
        float randomX = Random.Range(-moveDistance, moveDistance);
        float randomZ = Random.Range(-moveDistance, moveDistance);

        // Calculate the new target position
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        // Return the random position
        return randomPosition;
    }
}
