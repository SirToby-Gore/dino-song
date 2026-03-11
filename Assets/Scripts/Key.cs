using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();

        inventory.hasKey = true;

        Debug.Log("Key picked up!");

        Destroy(gameObject);
    }
}