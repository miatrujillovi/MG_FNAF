using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio6 : MonoBehaviour
{
    // Variables Publicas
    public Transform Cube;
    public float rotationSpeed;

    // Variables Privadas
    public float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        yRotation = 0f;

        // Los Objetos se rotan en Quaternianos
        Cube.rotation = Quaternion.Euler(45f, 0f, 45f);
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject(Cube);

        // Para que la Camara siga al Objeto
        Camera.main.transform.LookAt(Cube);
    }

    void RotateObject(Transform _Object)
    {
        // Rotate es HACIA donde quiero que rote, por lo tanto usa vectores
        // _Object.Rotate(new Vector3(0f, rotationSpeed * Time.deltaTime, 0f), Space.World);

        yRotation += rotationSpeed * Time.deltaTime;
        _Object.rotation = Quaternion.Euler(new Vector3(_Object.rotation.eulerAngles.x, yRotation, _Object.rotation.eulerAngles.z));
    }
}
