using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiFarola : MonoBehaviour
{

	public float tiempoParaCambiar = 1f;

	float tiempoAcumulado = 0;

	float intensidadInicial;

	Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {

		lightComponent = GetComponent<Light>();

		intensidadInicial = lightComponent.intensity;

        Debug.Log("Hola, soy una farola intermitnte");
    }

    // Update is called once per frame
    void Update()
    {
        
		tiempoAcumulado += Time.deltaTime;


		if (tiempoAcumulado > tiempoParaCambiar)
		{

			tiempoAcumulado = 0;


			if (lightComponent.intensity == 0)
			{
				lightComponent.intensity = intensidadInicial;
			} else
			{
				lightComponent.intensity = 0;
			}

			

		}

    }
}
