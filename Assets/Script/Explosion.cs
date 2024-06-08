using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radiusExplosion = 2;
    [SerializeField] private float _forceExplsion = 5;

    public void BlowingCube(Vector3 explosionPosition, int explosionMultiplier)
    {
        foreach (Rigidbody explodableCube in GetExplosionCubes(explosionPosition, explosionMultiplier))
        {
            explodableCube.AddExplosionForce(_forceExplsion * explosionMultiplier, explosionPosition, _radiusExplosion * explosionMultiplier);
        }
    }

    private List<Rigidbody> GetExplosionCubes(Vector3 explosionPosition, int radiusMultiplier)
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(explosionPosition, _radiusExplosion * radiusMultiplier);

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
