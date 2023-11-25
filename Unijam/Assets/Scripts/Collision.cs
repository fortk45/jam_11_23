using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionAtomes : MonoBehaviour
{
    public float vitesseRelativeMinimale = 5f; // Ajustez la vitesse minimale pour la collision


    [SerializeField]
    private Molecule[] tableauPrefabs;

    void Start()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        return;
        for (int i = 0; i < tableauPrefabs.Length; i++)
        {
            Molecule parent1 = gameObject.GetComponent<Molecule>();
            Molecule parent2 = collision.gameObject.GetComponent<Molecule>();
            if (parent1.moleculeType == tableauPrefabs[i].returnParent1().moleculeType)
            {
                if (parent2.moleculeType == tableauPrefabs[i].GetComponent<Molecule>().returnParent2().moleculeType)
                {
                    // Créer un nouvel objet à la position de la collision
                    GameObject ohObject = Instantiate(tableauPrefabs[i].gameObject, collision.contacts[0].point, Quaternion.identity);

                    // Renommer la nouvelle boule
                    ohObject.name = tableauPrefabs[i].name;

                    // Détruire les boules en collision
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    return;
                }

            }

            if (parent1.moleculeType == tableauPrefabs[i].GetComponent<Molecule>().returnParent2().moleculeType)
            {
                if (parent2.moleculeType == tableauPrefabs[i].GetComponent<Molecule>().returnParent1().moleculeType)
                {
                    // Créer un nouvel objet à la position de la collision
                    GameObject ohObject = Instantiate(tableauPrefabs[i].gameObject, collision.contacts[0].point, Quaternion.identity);

                    // Renommer la nouvelle boule
                    ohObject.name = tableauPrefabs[i].name;

                    // Détruire les boules en collision
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                    return;
                }
            }
            return;
        }



    }
}





