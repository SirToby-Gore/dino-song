using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public float destroyDelay = 1f; // Time in seconds before the object is destroyed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, destroyDelay); // Schedule the destruction of the game object after the specified delay
    }
}
