using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f; // Speed of the ball
    private Vector2 direction;

    void Start()
    {
        // Initialize a random direction
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        // Move the ball
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflect direction upon hitting a wall or barrier
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);

        if(collision.gameObject.tag=="Wall" && collision.gameObject.GetComponent<WallHandler>().IsWallExtending)
        {
            Destroy(collision.gameObject);
        }
    }
}
