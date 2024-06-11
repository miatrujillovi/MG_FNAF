using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio4 : MonoBehaviour
{
    // Variables Publicas
    public GameObject Cube;
    public Light myLight;

    // Update is called once per frame
    void Update()
    {
        moveCube();
    }

    // Funcion que mueve el cubo
    void moveCube()
    {
        //Time.deltaTime es el tiempo que transcurre del frame anterior al actual y sirve para acomodar los frames de forma justa
        //Cube.transform.position = new Vector3(Cube.transform.position.x -1f * Time.deltaTime, Cube.transform.position.y, Cube.transform.position.z);
        Cube.transform.Translate(new Vector3(-1f * Time.deltaTime, 0f, 0f));
    }

    // Funcion heredada que sirve para detectar cuando un objeto choca con el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myLight.enabled = true;
        }
    }

    // Funcion heredada que sirve para detectar cuando un objeto sale del trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myLight.enabled = false;
        }
    }

}
