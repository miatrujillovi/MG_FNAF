using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //Variables Privadas
    private bool isOpen;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de Variables
        animator = GetComponent<Animator>();
        isOpen = true;
        updateAnimation();  
    }

    //Funcion para cambiar estado de la puerta
    public void setIsOpen(bool _state)
    {
        isOpen = _state;
        updateAnimation();
    }

    //Funcion para regresar el estado de la puerta
    public bool IsOpen()
    {
        return isOpen;
    }

    //Funcion para actualizar el parametro del animator controller
    void updateAnimation()
    {
        animator.SetBool("isOpen", isOpen);
    }
}
