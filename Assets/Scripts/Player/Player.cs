using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;

    private float _mousePositionX;

    public float Speed 
    { 
        get { return _speed; } 
    }

    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _mousePositionX = Input.mousePosition.x;

        }

        if (Input.GetMouseButton(0)) 
        {
            float newPosition = Input.mousePosition.x - _mousePositionX;

            transform.position += new Vector3(newPosition, 0f, 0f) * Time.deltaTime * _speed;
            Mathf.Clamp(transform.position.x, -3.5f, 3.5f);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -3.5f, 3.5f),
                transform.position.y,
                transform.position.z);

            _mousePositionX = Input.mousePosition.x;
        }
    }

}
