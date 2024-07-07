using UnityEngine;

public class SpawnBomb : ObjectPool <Bomb>
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] protected Vector3 _scaleBomb;

    private int _countObject;
    private void Start()
    {
        Initialaze(_bombPrefab);
    }

    public void SetSpawnPosition(Vector3 position)
    { 
        Spawn(position);
    }

    private void Spawn(Vector3 position)
    {
        if (TryGetObject(out Bomb bomb))
        {
            SetObject(bomb, _scaleBomb);
            bomb.transform.position = position;


            CountActiveElements(bomb);
        }
    }
}
