using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    private List<Cube> _cubesScene = new List<Cube>();

    public void AddCube(Cube cube)
    { 
        _cubesScene.Add(cube);
    }

    public void RemoveCobe(Cube cube)
    {
        Cube tempCube = null;

        foreach (var item in _cubesScene)
        {
            if (item == cube)
            {
                tempCube = item; 
            }
        }

        _cubesScene.Remove(tempCube);
        Destroy(tempCube.gameObject);
    }

    public void SetSplitValue(Cube cube, int count)
    {
        foreach (var item in _cubesScene)
        {
            if (item == cube)
            {
                item.SetCountSplit(count);
            }
        }
    }
}
