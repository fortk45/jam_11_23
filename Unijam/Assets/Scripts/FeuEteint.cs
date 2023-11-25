using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeuEteint : MonoBehaviour
{
    public float vitesseRelativeMinimale = 5f; // Ajustez la vitesse minimale pour la collision

    void OnCollisionEnter(Collision collision)
    {
        // V�rifier si la collision a suffisamment de vitesse relative
        if (collision.relativeVelocity.magnitude > vitesseRelativeMinimale)
        {
            if (collision.gameObject.tag == "EAU")
            {
                // D�truire les boules en collision
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
