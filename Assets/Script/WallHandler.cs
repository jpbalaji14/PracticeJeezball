using UnityEngine;

public class WallHandler : MonoBehaviour
{
   [SerializeField] private SpriteRenderer _spriteRenderer;
    public GameObject Sibling;
    public bool IsWallExtending;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsWallExtending = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary" || collision.gameObject.tag == "Wall" && !collision.gameObject.GetComponent<WallHandler>().IsWallExtending)
        {
            _spriteRenderer.color = Color.black;
            transform.parent = null;
            IsWallExtending = false;

            if (Sibling != null)
            {
                Sibling.GetComponent<WallHandler>().Sibling = null;
                Sibling = null;
            }
        }
    }
}
