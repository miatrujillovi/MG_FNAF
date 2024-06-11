using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio1 : MonoBehaviour
{
    // Variables Publicas
    public float number1, number2;
    public float[] numbers;

    /* Variables Privadas
    SerializeField hace que las variables privadas aparezcan en el editor de Unity
    [SerializeField] private float number2; */

    //private float[] pNumbers = new float[5];
    private float[] pNumbers = {1f, 2f, 3f, 4f, 5f}; 

    // Start is called before the first frame update
    void Start()
    {
        //Imprimir en pantalla
        Debug.Log("Numero 1: " + number1 + " y Numero 2: " + number2);
        Debug.Log("Suma: " + Add(number1, number2));
        float _multiplicacion = Multiply();
        Debug.Log("Multiplicacion: " + _multiplicacion);
        Debug.Log("Sumatoria de Arreglo Publico: " + Sumatoria(numbers));
        Debug.Log("Sumatoria de Arreglo Privado: " + Sumatoria(pNumbers));

        /* Darle valor a la variable desde el Start
        pNumbers = new float[5];*/

    }

    //Funcion que suma variables
    float Add(float _number1, float _number2)
    {
        return _number1 + _number2;
    }

    //Funcion que multiplica variables
    float Multiply()
    {
        return number1 * number2;
    }

    // Funcion que suma valores dentro de un array
    float Sumatoria(float[] _array)
    {
        float _sumatoria = 0f;
        /*for (int i = 0; i < _array.Length; i++)
        {
            _sumatoria += _array[i];
        }*/

        foreach(float _number in _array)
        {
            _sumatoria += _number;
        }

        return _sumatoria;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
