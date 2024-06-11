using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Variables Publicas
    public float rotationSpeed, yMinRotation, yMaxRotation;

    // Variables Privadas
    private float yRotation;

    // Funcion para mover la camara
    public void CameraRotation()
    {
        // Movimiento a la Derecha
        if(Input.mousePosition.x > Screen.width * 0.95f)
        {
            yRotation += rotationSpeed * Time.deltaTime;
        }
        // Movimiento a la Izquierda
        else if(Input.mousePosition.x < Screen.width * 0.05f)
        {
            yRotation -= rotationSpeed * Time.deltaTime;
        }

        // Angulo de Rotacion (Evita que el Angulo sube o baje entre dos Parametros)
        yRotation = Mathf.Clamp(yRotation, yMinRotation, yMaxRotation);
        Camera.main.transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }

}
