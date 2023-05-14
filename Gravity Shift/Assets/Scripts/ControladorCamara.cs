using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{
    public Transform personaje;

    public Transform fondolejano, fondocercano;

    private Vector2 ultimaposicion;

    // Start is called before the first frame update
    void Start()
    {
        ultimaposicion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(personaje.position.x, personaje.position.y, transform.position.z);

        Vector2 cantidadAMover = new Vector2(transform.position.x - ultimaposicion.x, transform.position.y - ultimaposicion.y);

        fondolejano.position = fondolejano.position + new Vector3(cantidadAMover.x * .5f, cantidadAMover.y * .25f, 0f);
        fondocercano.position += new Vector3(cantidadAMover.x * .5f, cantidadAMover.y * .10f, 0f);

        ultimaposicion = transform.position;
    }

}
