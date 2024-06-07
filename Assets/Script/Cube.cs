using UnityEngine;

public class Cube : MonoBehaviour
{
    public int CountSplit { get; private set; }

    public void SetCountSplit(int count)
    {
        CountSplit += count;
    }
}
