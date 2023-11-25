using Assets.Scripts;
using System.Collections;
using UnityEngine;

public enum MoleculeType
{
    None,
    H,
    O,
}

public class Molecule : MonoBehaviour
{
    public MoleculeType moleculeType;
    private bool canCollide = true;

    [SerializeField] Molecule parent1;
    [SerializeField] Molecule parent2;

    public Molecule returnParent1()
    {
        return this.parent1;
    }

    public Molecule returnParent2()
    {
        return this.parent2;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canCollide && collision.collider.TryGetComponent(out Molecule other))
        {
            Debug.Log("Message");
            other.canCollide = false;
            FusionManager.Instance.ResolveCollision(this, other);
        }
    }
}
