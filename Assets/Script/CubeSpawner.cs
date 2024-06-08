using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Material[] _materials;
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private ChanceCounter _chanceCounter;
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private Collider _spawnTerritory;

    [SerializeField] private int _minCountCubes;
    [SerializeField] private int _maxCountCubes;
    [SerializeField] private int _splitterCube = 2;

    private Transform _transform;
    private Vector3 _spawnBound;

    private void OnEnable()
    {
        _clickHandler.Clecked += OnClicked;
    }

    private void OnDisable()
    {
        _clickHandler.Clecked -= OnClicked;
    }

    private void Awake()
    {
        _transform = transform;
        _spawnBound = _spawnTerritory.bounds.extents;
    }

    private void Start()
    {
        for (int i = 0; i < _maxCountCubes; i++)
        {
            SpawnCube(GetSpawtPosition());
        }
    }

    private void OnClicked(Cube cube)
    { 
       SplitCube(cube);
    }

    private Cube SpawnCube(Vector3 position)
    { 
        return Instantiate(_prefabCube, position, Quaternion.identity);
    }

    private void SplitCube(Cube cubesInScene)
    {
        if (_chanceCounter.IsCreatedChance(cubesInScene))
        {
            int tempValue = cubesInScene.CountSplit;
            tempValue++;

            int countCubes = Random.Range(_minCountCubes, _maxCountCubes);

            for (int i = 0; i < countCubes; i++)
            {
                Cube cube = SpawnCube(cubesInScene.transform.position);
                cube.transform.localScale = cubesInScene.transform.localScale / _splitterCube;
                cube.GetComponent<Renderer>().material = ChangeColor();
                cube.SetCountSplit(tempValue);
            }

            _explosion.BlowingCube(transform.position, cubesInScene.CountSplit);
        }

        Destroy(cubesInScene.gameObject);
    }

    private Material ChangeColor()
    { 
        int index = Random.Range(0, _materials.Length);

        return _materials[index];
    }

    private Vector3 GetSpawtPosition()
    {
        float vectorX = Random.Range(_spawnBound.x, -_spawnBound.x);
        float vectorZ = Random.Range(_spawnBound.z, -_spawnBound.z);

        Vector3 spawtPosition = new Vector3(vectorX, _transform.position.y, vectorZ);

        return spawtPosition;
    }
}
