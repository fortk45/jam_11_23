using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionAtomes : MonoBehaviour
{
    public float vitesseRelativeMinimale = 5f; // Ajustez la vitesse minimale pour la collision
    public GameObject ohPrefab; // D�finissez le pr�fabriqu� de la nouvelle boule OH dans l'�diteur Unity

    void OnCollisionEnter(Collision collision)
    {
        // V�rifier si la collision a suffisamment de vitesse relative
        if (collision.relativeVelocity.magnitude > vitesseRelativeMinimale)
        {
            // Cr�er un nouvel objet OH � la position de la collision
            GameObject ohObject = Instantiate(ohPrefab, collision.contacts[0].point, Quaternion.identity);

            // Renommer la nouvelle boule OH
            ohObject.name = "OH";

            // D�truire les boules en collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Debug.Log("Nouvelle boule OH cr��e avec succ�s!");
        }
    }
}




