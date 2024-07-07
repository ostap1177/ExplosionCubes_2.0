using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BombeDestroyer : MonoBehaviour
{
    [SerializeField] private int _minDuration;
    [SerializeField] private int _maxDuration;
    [SerializeField] private Explosion _explosion;

    private int _second = 1;
    private WaitForSeconds _delay;
    private Coroutine _coroutine;
    private Renderer _renderer;
    private Transform _transform;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _delay = new WaitForSeconds(_second);
        _transform = transform;
    }

    public void ChangeTransparency()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ControlTransparency());
    }

    private IEnumerator ControlTransparency()
    {
        int duration = SetDuration();
        float step = _renderer.material.color.a / duration;

        for (int i = 0; i <= duration; i++)
        {
            _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, Mathf.MoveTowards(_renderer.material.color.a, 0, step));

            yield return _delay;
        }

        _explosion.Explode(_transform.position);
        _renderer.material.color = Color.black;
        Deactivate();
    }

    private int SetDuration()
    { 
        return Random.Range(_maxDuration, _maxDuration);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
