using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material [] _materials;

    private bool _isChahged = false;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;  
    }

    public void Change()
    {
        if (_isChahged == false)
        {
            _isChahged=true;
            _renderer.material = GetMaterial();
        }
    }

    public void ResetColor()
    { 
        _isChahged = false;
        _renderer.material = _defaultMaterial;
    }

    private Material GetMaterial()
    {
        int index = Random.Range(0,_materials.Length-1);

        return _materials[index];   
    }
}
