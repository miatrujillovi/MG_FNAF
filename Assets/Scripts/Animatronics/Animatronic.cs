using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatronic : MonoBehaviour
{
    //Variables Publicas
    public float timeToMove, probabilityOfMoving;
    public Transform[] positions;
    public Door door;
    public GameObject jumpscareMesh;

    //Variables Privadas
    private int positionIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de Variables
        positionIndex = 0;
        StartCoroutine(MovementCoroutine(Random.Range(timeToMove -5f, timeToMove +5f)));
    }

    //Funcion de Movimiento
    public void Move()
    {
        //Calcular la probabilidad para moverse
        if (Random.Range(0f, 100f) <= probabilityOfMoving)
        {
            //Verificar si estamos en la puerta
            if (positionIndex == positions.Length - 1)
            {
                //Verificamos si la puerta esta abierta
                if (door == null || door.IsOpen())
                {
                    //Atacamos
                    StopAllCoroutines();
                    Attack();
                    return;
                } else
                {
                    //Regresamos al inicio
                    positionIndex = 0;
                    transform.position = positions[positionIndex].position;
                    transform.rotation = positions[positionIndex].rotation;
                }
            }
            else
            {
                //Nos movemos a la siguiente posicion
                positionIndex++;
                transform.position = positions[positionIndex].position;
                transform.rotation = positions[positionIndex].rotation;
            }
        }
        //Iniciamos la corrutina para el siguiente movimiento
        StartCoroutine(MovementCoroutine(Random.Range(timeToMove - 5f, timeToMove + 5f)));
    }

    //Funcion para Atacar
    public void Attack()
    {
        jumpscareMesh.SetActive(true);
        LevelManager.Instance.PlayerDead();
    }

    //Corrutina de Movimiento
    IEnumerator MovementCoroutine(float _time)
    {
        //Esperamos el tiempo para hacer un movimiento
        yield return new WaitForSeconds(_time);

        //Intentamos movernos
        Move();
    }
}
