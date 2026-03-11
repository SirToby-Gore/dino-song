using UnityEngine;

public class EnteringDoor : MonoBehaviour
{
    public TargetDoor targetDoor;
    public bool requiresKey = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        PlayerInventory inventory = collision.GetComponent<PlayerInventory>();

        if (requiresKey && !inventory.hasKey)
        {
            Debug.Log("Door is locked. Need a key.");
            return;
        }

        Debug.Log("Teleporting player");

        collision.transform.position = targetDoor.spawnPoint.position;
    }
}