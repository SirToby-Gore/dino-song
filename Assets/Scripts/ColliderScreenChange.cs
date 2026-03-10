using UnityEngine;

public class ColliderScreenChange : MonoBehaviour
{
    private float positionX;


    public Transform nextSceneCenter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.transform.position = new Vector3(nextSceneCenter.position.x, nextSceneCenter.position.y, -25f); // Move the camera to the next scene's center position
        }
    }
}
//Github test commit
