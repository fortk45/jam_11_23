using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class FusionManager : MonoBehaviour
    {
        public static FusionManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public float vitesseRelativeMinimale = 5f; // Ajustez la vitesse minimale pour la collision

        [SerializeField]
        private Molecule[] tableauPrefabs;

        void Start()
        {
        }

        public void ResolveCollision(Molecule molecule1, Molecule molecule2)
        {
            for (int i = 0; i < tableauPrefabs.Length; i++)
            {
                
                if (molecule1.moleculeType == tableauPrefabs[i].returnParent1().moleculeType &&
                    molecule2.moleculeType == tableauPrefabs[i].returnParent2().moleculeType)
                {
                    Debug.Log("Condition 1 satisfied.");

                    // Créer un nouvel objet à la position de la collision
                    GameObject ohObject = Instantiate(tableauPrefabs[i].gameObject, (molecule1.transform.position + molecule2.transform.position) / 2f, Quaternion.identity);

                    // Renommer la nouvelle boule
                    ohObject.name = tableauPrefabs[i].name;

                    // Détruire les boules en collision
                    Destroy(molecule1.gameObject);
                    Destroy(molecule2.gameObject);
                    return;
                }

                if (molecule1.moleculeType == tableauPrefabs[i].returnParent2().moleculeType &&
                    molecule2.moleculeType == tableauPrefabs[i].returnParent1().moleculeType)
                {
                    Debug.Log("Condition 2 satisfied.");

                    // Créer un nouvel objet à la position de la collision
                    GameObject ohObject = Instantiate(tableauPrefabs[i].gameObject, (molecule1.transform.position + molecule2.transform.position) / 2f, Quaternion.identity);

                    // Renommer la nouvelle boule
                    ohObject.name = tableauPrefabs[i].name;

                    // Détruire les boules en collision
                    Destroy(molecule1.gameObject);
                    Destroy(molecule2.gameObject);
                    return;
                }
            }
        }

    }
}
