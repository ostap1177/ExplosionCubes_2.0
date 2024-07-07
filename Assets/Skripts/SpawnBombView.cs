using TMPro;
using UnityEngine;

public class SpawnBombView : MonoBehaviour
{
    [SerializeField] private ObjectPool<Bomb> _spawner;

    [SerializeField] private TextMeshProUGUI _textCountCreate;
    [SerializeField] private TextMeshProUGUI _textCountActive;

    private string _startValue = "0";

    private void OnEnable()
    {
        _spawner.CountedCreate += OnCountedCreate;
        _spawner.CountedActive += OnCountedActive;
    }

    private void OnDisable()
    {
        _spawner.CountedCreate -= OnCountedCreate;
        _spawner.CountedActive -= OnCountedActive;
    }

    private void Awake()
    {
        _textCountCreate.text = _startValue;
        _textCountActive.text = _startValue;
    }

    private void OnCountedCreate(int count)
    {
        _textCountCreate.text = count.ToString();
    }

    private void OnCountedActive(int count)
    {
        _textCountActive.text = count.ToString();
    }
}
