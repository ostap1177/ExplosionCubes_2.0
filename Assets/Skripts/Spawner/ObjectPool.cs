using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected int CountCreateObject = 0;
    protected int CountActiveObject;

    //private List<GameObject> _pool = new List<GameObject>();
    private List<T> _pool = new List<T>();

    public event UnityAction<int> CountedCreate;
    public event UnityAction<int> CountedActive;

/*    private void FixedUpdate() 
    {
        CountActiveElements();
    }*/

    protected void Initialaze(T prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            T objectInGame = Instantiate(prefab, _container.transform);
            objectInGame.gameObject.SetActive(false);

            _pool.Add(objectInGame);
        }
    }

    protected bool TryGetObject(out T result)
    {
        result = null;

        foreach(T obj in _pool) 
        {
            if (obj.TryGetComponent<T>(out T entity) && !entity.gameObject.activeInHierarchy)
            {
                result = entity;    
            }
        }

        return result != null;
    }


    protected void SetObject(Entity entity, Vector3 scale)
    {
        entity.gameObject.SetActive(true);
        entity.transform.localScale = scale;
        CountCreateObject++;
        CountElements();
    }

    private void CountElements()
    {
        CountedCreate?.Invoke(CountCreateObject);
    }

    protected void CountActiveElements(Entity entity)
    {
       // int count = _pool.Count(p => p.activeSelf);

        int count = 0;  

        foreach (T obj in _pool)
        {
            if (obj.TryGetComponent(out Entity entity1) && !entity.gameObject.activeInHierarchy)
            {
                count++;
            }

        }

        CountedActive?.Invoke(count);
    }

    /*    protected void Initialaze (T prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject objectInGame = Instantiate(prefab.gameObject, _container.transform);
                objectInGame.SetActive(false);

                _pool.Add(objectInGame);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);

            return result != null;
        }*/

    /*    protected void ResetPoll()
        {
            foreach (var item in _pool)
            {
                item.SetActive(false);
            }
        }*/
}
