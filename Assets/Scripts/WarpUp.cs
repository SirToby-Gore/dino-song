using UnityEngine;

public class WarpUp : MonoBehaviour
{
    public Rigidbody2D player_body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 pos = player_body.transform.position;
            pos.y += 12.5f;
            player_body.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
