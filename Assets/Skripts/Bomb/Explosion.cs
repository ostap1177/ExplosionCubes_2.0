using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int _forceExplsion;
    [SerializeField] private int _radiusExplosion;

    public void Explode(Vector3 explosionPosition)
    {
        foreach (Rigidbody explodableCube in GetExplosion(explosionPosition))
        {
            explodableCube.AddExplosionForce(_forceExplsion, explosionPosition, _radiusExplosion);
        }
    }

    private List<Rigidbody> GetExplosion(Vector3 explosionPosition)
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(explosionPosition, _radiusExplosion);

        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider collider in overlappedColliders)
        {
            if (collider.attachedRigidbody != null)
            {
                cubes.Add(collider.attachedRigidbody);
            }
        }

        return cubes;
    }
}
