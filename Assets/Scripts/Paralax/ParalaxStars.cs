using System.Collections.Generic;
using UnityEngine;

public class ParalaxStars : MonoBehaviour
{
    //field for set speed with which we moving our objects
    //and field for set our backgrounds
    [SerializeField] private float _speed;
    [SerializeField] private List<GameObject> _foreground = new List<GameObject>();
    [SerializeField] private List<GameObject> _background = new List<GameObject>();

    //Property for set offset backrounds speed from extern 
    public float Speed
    {
        set
        {
            _speed = value;
        }
    }

    //field for our constant position Y for translate our backgrounds when it out of view
    private const float Y_POSITION = 15f;


    private void Update()
    {
        MoveBackgrounds(_foreground, _speed);
        MoveBackgrounds(_background, _speed / 3f);
    }

    private void MoveBackgrounds(List<GameObject> listObjects, float speed)
    {
        foreach(var obj in listObjects)
        {
            obj.transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);

            if (obj.transform.position.y <= -Y_POSITION)
            {
                obj.transform.position = new Vector2(0f, Y_POSITION);
            }
        }
    }
    

}
