using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Funcion de Interaccion
    public void Interaction()
    {
        // Si presiono el Clic Izquierdo = 0
        if (Input.GetMouseButtonDown(0))
        {
            // Esto crea un "rayo" que detecta donde apunta el Mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;
            if (Physics.Raycast(ray, out _hit, 100))
            {
                // Si el "rayo" entra en contacto con un objeto interactivo
                if (_hit.transform.gameObject.GetComponent<InteractableObject>() != null)
                {
                    _hit.transform.gameObject.GetComponent<InteractableObject>().Interact();
                }
            }
        }
    }
}
