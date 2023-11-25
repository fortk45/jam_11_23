using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomeScript : MonoBehaviour
{
    public float forceFlottement = 5f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Ajoute une force aléatoire pour simuler le flottement
        Vector3 forceAleatoire = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
        rb.AddForce(forceAleatoire * forceFlottement, ForceMode.Impulse);
    }
}


