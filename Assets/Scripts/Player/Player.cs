using Unity.VisualScripting;
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

    public void Death()
    {
        //TODO: DEATH made methods across pool, or just setactive
    }

    public void ShieldEffect()
    {
        //TODO: For some second shield effect
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

            Vector3 newPos = transform.position + new Vector3(newPosition, 0f, 0f) * Time.deltaTime * _speed;
            newPos.x = Mathf.Clamp(newPos.x, -3.5f, 3.5f);
            transform.position = newPos;

            _mousePositionX = Input.mousePosition.x;
        }
    }
}
