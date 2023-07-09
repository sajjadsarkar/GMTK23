using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;  // The prefab to instantiate
    public int initialCount = 5;     // Number of objects to instantiate initially
    public int additionalCount = 5;  // Number of objects to instantiate if all are destroyed

    private int totalCount;          // Total count of instantiated objects
    private int destroyedCount;      // Count of destroyed objects

    public AudioSource audioSource;
    private void Start()
    {
        InstantiateObjects(initialCount);
    }

    private void InstantiateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(objectPrefab, RandomPosition(), Quaternion.identity);
            totalCount++;
        }
    }

    private Vector3 RandomPosition()
    {
        // Modify this method according to your desired spawn area or position logic
        return new Vector3(Random.Range(-200f, 200f), Random.Range(-30f, 30f), Random.Range(100f, 100f));
    }

    private void Update()
    {
        // Check if all objects are destroyed
        if (destroyedCount == totalCount)
        {
            InstantiateObjects(additionalCount);
            destroyedCount = 0;  // Reset the count of destroyed objects
        }
    }

    // Call this method whenever an instantiated object is destroyed
    public void ObjectDestroyed()
    {
        audioSource.Play();
        destroyedCount++;
        Debug.Log(destroyedCount);
    }
}
