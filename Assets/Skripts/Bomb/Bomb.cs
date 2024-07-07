using UnityEngine;

public class Bomb : Entity
{
    [SerializeField] private BombeDestroyer _bombeDestroyer;

    private void Start()
    {
        _bombeDestroyer.ChangeTransparency();
    }
}
