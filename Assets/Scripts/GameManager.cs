using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject levelEndObject; // Reference to the level end object

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            EndLevel();
        }*/ // Testing code
    }

    public void EndLevel()
    {
        // Activate the level end object to signify the end of the level
        if (levelEndObject != null)
        {
            levelEndObject.SetActive(true);
        }
    }
}
