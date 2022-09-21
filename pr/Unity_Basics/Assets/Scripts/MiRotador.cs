using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiRotador : MonoBehaviour
{

	public int velocidadDeGiro = 30;

	bool mensajeEnviado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		transform.Rotate(0, velocidadDeGiro * Time.deltaTime, 0);


		if (velocidadDeGiro > 500 && mensajeEnviado == false) {
			Debug.Log("Dale, dale, pon más a ver qué pasa...");
			mensajeEnviado = true;
		}

        
    }
}
