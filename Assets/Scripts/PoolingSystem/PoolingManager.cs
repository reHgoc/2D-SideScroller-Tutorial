using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingManager<T>
    where T : MonoBehaviour
{
    private T _prefab;
    private List<T> _objects;

    public PoolingManager(T prefab, List<T> objects)
    {
        _prefab = prefab;
        _objects = objects;

        for(int i = 0; i < _objects.Count; i++)
        {
            var obj = GameObject.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _objects.Add(obj);
        }
    }

    public T Get()
    {
        var obj = _objects.FirstOrDefault(x => !x.isActiveAndEnabled);

        if (obj == null) 
        {
            obj = Create();
        }

        obj.gameObject.SetActive(true);

        return obj;
    }

    public T Create()
    {
        var obj = GameObject.Instantiate(_prefab);
        _objects.Add(obj);

        return obj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }


}
