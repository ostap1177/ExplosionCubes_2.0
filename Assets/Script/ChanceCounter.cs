using UnityEngine;

public class ChanceCounter : MonoBehaviour
{
    [SerializeField] private int _maxValueToChance = 10;
    [SerializeField] private int _maxChanceValue = 20;
    public bool IsCreatedChance(Cube cube)
    {
        int value = Random.Range(0, _maxChanceValue);

        if (cube.CountSplit > 0)
        {
            return value < _maxValueToChance / cube.CountSplit;
        }
        else 
        {
            return value < _maxValueToChance;
        }
    }
}
