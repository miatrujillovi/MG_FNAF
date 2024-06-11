using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio3 : MonoBehaviour
{
    // Variables Publicas
    // Guardar todo un objeto en una variable
    public GameObject myLight;
    public Light myLightComponent;

    // Variables Privadas
    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchLight();
    }

    //Funcion para Prender y Apagar Luz
    void SwitchLight()
    {
        /* GetKey = Ejecuta en cada frame
        // GetKeyDown = Ejecuta al presionar la tecla
        // GetkeyUp = Ejecuta hasta que dejas de presionar la tecla */
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isOn == true)
            {
                //myLight.SetActive(false);
                //myLight.GetComponent<Light>().enabled = false;
                //myLight.GetComponent<Light>().intensity = 0f;
                myLightComponent.enabled = false;
                isOn = false;   
            }
            else
            {
                //myLight.SetActive(true);
                //myLight.GetComponent<Light>().enabled = true;
                //myLight.GetComponent<Light>().intensity = 1f;
                myLightComponent.enabled = true;
                isOn = true;
            }
        }
    }
}
