using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{
    // Variables Privadas
    [SerializeField] private int firstNumber, lastNumber, loop;
    // Start is called before the first frame update
    void Start()
    {
        switch (loop)
        {
            case 1:
                UsingForLoop();
                break;
            case 2:
                UsingWhileLoop();   
                break;
            case 3:
                StartCoroutine(OnePerSecond());
                break;
            case 4:
                StartCoroutine(OnePerFrame());
                break;
            default:
                Debug.Log("Numero Invalido");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UsingForLoop()
    {
        for (int i = firstNumber; i <= lastNumber; i++)
        {
            Debug.Log(i);
            // Lerp recibe 3 variables, una inicial, otra final y el alfa que determina la variable que te devolvera
            if (i == Mathf.Lerp(firstNumber, lastNumber, 0.5f))
            {
                Debug.Log("Mitad del Camino");
            }
        }
        Debug.Log("Terminado con un Ciclo For");
    }

    // Las Corutinas son funciones que no ocupan realizar todo en el mismo frame, por lo que se pueden manejar en el tiempo, por ejemplo, animaciones
    IEnumerator OnePerSecond()
    {
        for (int i = firstNumber; i <= lastNumber; i++)
        {
            Debug.Log(i);
            // Lerp recibe 3 variables, una inicial, otra final y el alfa que determina la variable que te devolvera
            if (i == Mathf.Lerp(firstNumber, lastNumber, 0.5f))
            {
                Debug.Log("Mitad del Camino");
            }
            // yield maneja el tiempo
            yield return new WaitForSeconds(1f); 
        }
        Debug.Log("Terminado Uno en Cada Segundo");
    }

    IEnumerator OnePerFrame()
    {
        for (int i = firstNumber; i <= lastNumber; i++)
        {
            Debug.Log(i);
            // Lerp recibe 3 variables, una inicial, otra final y el alfa que determina la variable que te devolvera
            if (i == Mathf.Lerp(firstNumber, lastNumber, 0.5f))
            {
                Debug.Log("Mitad del Camino");
            }
            // yield maneja el tiempo
            yield return null;
        }
        Debug.Log("Terminado Uno en Cada Frame");
    }

    void UsingWhileLoop()
    {
        int _index = firstNumber;
        while (_index <= lastNumber)
        {
            Debug.Log(_index);
            _index++;
        }
        Debug.Log("Terminado con un Ciclo While");
    }
}
