using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _wallPrefab;
    private GameObject _wallOne;
    private GameObject _wallTwo;
    public Vector3 MarkerRotation;
    public float ScaleSpeed=0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _wallOne = Instantiate(_wallPrefab);
        _wallOne.transform.position= this.transform.position;
        _wallOne.GetComponent<SpriteRenderer>().color = Color.red;
        BoxCollider2D _boxCollider = _wallOne.GetComponent <BoxCollider2D>();
        float width = _boxCollider.bounds.size.x;
        float height = _boxCollider.bounds.size.y;
        _wallOne.transform.SetParent(transform, true);
        _wallOne.transform.position = new Vector3(transform.position.x, transform.position.y+ height/2, 0);

        _wallTwo = Instantiate(_wallPrefab);
        _wallTwo.transform.position = this.transform.position;
        _wallTwo.GetComponent<SpriteRenderer>().color = Color.blue;
        _wallTwo.transform.SetParent(transform, true);
        _wallTwo.transform.position = new Vector3(transform.position.x , transform.position.y - height/2, 0);
        
        _wallOne.GetComponent<WallHandler>().Sibling = _wallTwo;
        _wallTwo.GetComponent<WallHandler>().Sibling = _wallOne;
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.eulerAngles != MarkerRotation)
        {
            transform.eulerAngles = MarkerRotation;
        }

        float yScale = transform.localScale.y;
        yScale += ScaleSpeed;
        transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);

        if (transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
