using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionAtomes : MonoBehaviour
{
    public float vitesseRelativeMinimale = 5f; // Ajustez la vitesse minimale pour la collision
    public GameObject ohPrefab; // Définissez le préfabriqué de la nouvelle boule OH dans l'éditeur Unity

    void OnCollisionEnter(Collision collision)
    {
        // Vérifier si la collision a suffisamment de vitesse relative
        if (collision.relativeVelocity.magnitude > vitesseRelativeMinimale)
        {
            // Créer un nouvel objet OH à la position de la collision
            GameObject ohObject = Instantiate(ohPrefab, collision.contacts[0].point, Quaternion.identity);

            // Renommer la nouvelle boule OH
            ohObject.name = "OH";

            // Détruire les boules en collision
            Destroy(collision.gameObject);
            Destroy(gameObject);

            Debug.Log("Nouvelle boule OH créée avec succès!");
        }
    }
}




