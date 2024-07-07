using System.Collections;
using UnityEngine;

public class DestroyerCube : MonoBehaviour
{
    [SerializeField] private int _minDelayDestroy;
    [SerializeField] private int _maxDelayDestroy;


    private Coroutine _destroyCoroutine;
    private WaitForSeconds _waitForSeconds;
    private Transform _transform;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(SetTimeDestroy());
        _transform = transform;
    }

    public void DestroyCube()
    {
        if (_destroyCoroutine != null)
        {
            StopCoroutine(_destroyCoroutine);
        }

        _destroyCoroutine = StartCoroutine(DelaySpawnOre());
    }

    private IEnumerator DelaySpawnOre()
    {
        yield return _waitForSeconds;

        Deactivate();
    }

    private void Deactivate()
    {
        SetDestroyPosition();
        gameObject.SetActive(false);
    }

    private int SetTimeDestroy()
    {
        return Random.Range(_minDelayDestroy, _maxDelayDestroy);
    }

    private void SetDestroyPosition()
    {
        if (_transform.parent.TryGetComponent(out SpawnBomb spawnerBomb))
        {
            spawnerBomb.SetSpawnPosition(_transform.position);
        }
    }
}
