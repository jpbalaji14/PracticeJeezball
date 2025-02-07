using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MarkerController : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        Vector3 _mousePosition = Input.mousePosition;
        Vector3 _worldPosition = Camera.main.ScreenToWorldPoint(_mousePosition);
        transform.position = new Vector3(_worldPosition.x, _worldPosition.y, transform.position.z);
        
        if (transform.position.x > -15f && transform.position.x < 15f && transform.position.y < 7 && transform.position.y > -7 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject _wallObject = Instantiate(_wallPrefab);
                _wallObject.transform.position = this.transform.position;
                _wallObject.GetComponent<WallGenerator>().MarkerRotation = transform.eulerAngles;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.position = Vector3.zero;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 _currentAngle = this.transform.eulerAngles;
            _currentAngle.z += 90;
            transform.eulerAngles = _currentAngle;
        }
    }

    //GameObject _currentWallGenerator;
    //void Update()
    //{
    //    //todo: ensure we can't create walls outside the play area
    //    //move character
    //    Vector3 mousePos = Input.mousePosition;
    //    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
    //    transform.position = new Vector3(worldPoint.x, worldPoint.y, transform.position.z);

    //    //create WallGenerator
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (_currentWallGenerator == null)
    //        {
    //            _currentWallGenerator = Instantiate(_wallPrefab) as GameObject;
    //            _currentWallGenerator.transform.position = transform.position;
    //            _currentWallGenerator.GetComponent<WallGenerator>().MarkerRotation = transform.eulerAngles;
    //        }
    //    }

    //        if (Input.GetMouseButtonDown(1))
    //        {
    //            Vector3 currentEul = transform.eulerAngles;
    //            currentEul.z += 90;
    //            transform.eulerAngles = currentEul;
    //        }
        
    //}
}
