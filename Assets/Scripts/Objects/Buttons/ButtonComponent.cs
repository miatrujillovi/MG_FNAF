using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonComponent : MonoBehaviour
{
    // Variables Publicas
    public Material materialOn, materialOff, materialDisabled;
    public UnityEvent onActivated, onDeactivated;

    // Variables Privadas
    private bool buttonState;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializacion de Variables
        buttonState = false;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materialOff;
    }

    public void Switch ()
    {
        if (buttonState == false)
        {
            buttonState = true;
            meshRenderer.material = materialOn;
            onActivated.Invoke();
        }
        else
        {
            buttonState = false;
            meshRenderer.material = materialOff;
            onDeactivated.Invoke();
        }
    }
}
