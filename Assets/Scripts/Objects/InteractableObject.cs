using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    // Variable Publica
    public UnityEvent onInteract;

    public void Interact()
    {
        onInteract.Invoke();
    }
}
