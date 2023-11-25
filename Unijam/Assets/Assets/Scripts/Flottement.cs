using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlottementSpheriqueScript : MonoBehaviour
{
    public float forceRappel = 5f;
    public float forceGravite = 9.8f;
    public float forceFlottante = 1f;
    public float intervalleChangementDirection = 2f;

    private Vector3 positionOriginale;
    private Vector3 directionAleatoire;

    void Start()
    {
        positionOriginale = transform.position;
        directionAleatoire = Random.onUnitSphere;

        // Lancer la coroutine pour changer la direction p�riodiquement
        StartCoroutine(ChangerDirectionPeriodiquement());
    }

    void FixedUpdate()
    {

        Vector3 directionRappel = positionOriginale - transform.position;
        GetComponent<Rigidbody>().AddForce(directionRappel * forceRappel);

        // Ajouter un mouvement al�atoire
        Vector3 mouvementAleatoire = directionAleatoire * forceFlottante;
        GetComponent<Rigidbody>().AddForce(mouvementAleatoire);

        // Ajouter la force de gravit�
        GetComponent<Rigidbody>().AddForce(Vector3.down * forceGravite);
    }

    IEnumerator ChangerDirectionPeriodiquement()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalleChangementDirection);

            // Changer la direction al�atoire
            directionAleatoire = Random.onUnitSphere;
        }
    }
}


