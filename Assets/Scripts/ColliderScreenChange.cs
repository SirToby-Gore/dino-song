using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderScreenChange : MonoBehaviour
{
    private float positionX;

    private PlayerMovement playerMovement;

    public string sceneToLoad;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            positionX = gameObject.transform.position.x;
            SceneManager.LoadScene(sceneToLoad);
            playerMovement.transform.position.x = positionX;
        }
    }
}
