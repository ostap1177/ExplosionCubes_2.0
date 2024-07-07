using UnityEngine;

public class CubesCollisionHandler : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private DestroyerCube _destroyerCube;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<Platform>(out Platform platform))
        {
            _colorChanger.Change();
        }
        else if (collision.transform.TryGetComponent<Ground>(out Ground ground))
        {
            _colorChanger.Change();
            _destroyerCube.DestroyCube();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.TryGetComponent<SpawnCubes>(out SpawnCubes spawnCubes))
        {
            _colorChanger.ResetColor();
        }
    }
}
