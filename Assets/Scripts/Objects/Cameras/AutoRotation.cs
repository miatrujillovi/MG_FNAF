using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AutoRotation : MonoBehaviour
{
    //Variables Publicas
    public float rotationLimit, rotationSpeed;

    //Variables Privadas
    private float originalYRotation, yRotation;
    private int orientation;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de Variables
        originalYRotation = transform.localEulerAngles.y;
        yRotation = transform.localEulerAngles.z;
        orientation = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion para rotar
    void Rotation()
    {
        //Si llegamos a alguno de los limites de rotacion entonces cambiamos la orientacion
        if (transform.localEulerAngles.y <= originalYRotation - rotationLimit||transform.localEulerAngles.y >= originalYRotation + rotationLimit)
        {
            ChangeOrientation();
        }

        //Rotamos
        yRotation += rotationSpeed * orientation * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);
    }

    //Funcion para cambiar la orientacion
    void ChangeOrientation()
    {
        orientation *= 1;
    }
}
