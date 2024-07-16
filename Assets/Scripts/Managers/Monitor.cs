using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    //Variables Publicas
    public GameObject camerasPanel;
    public GameObject[] cameras;
    public AudioSource monitorAS, buttonAS;

    //Variables Privadas
    private int currentCamera;

    //Singleton
    public static Monitor Instance { get; private set; }

    private void Awake()
    {
        //Verificacion del Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de Variables
        currentCamera = 0;
    }

    //Funcion para activar una camara
    public void EnableCamera(int _index)
    {
        //Desactivamos camara actual y activamos la nueva
        cameras[currentCamera].SetActive(false);
        cameras[_index].SetActive(true);
        currentCamera = _index;
        buttonAS.Play();

        //Si la camara es DONDE ESTA la musicbox, activamos UI
        if (currentCamera == 2)
        {
            MusicBox.Instance.SetStateUI(true);
        }
        else
        {
            MusicBox.Instance.SetStateUI(false);

        }
    }

    //Funcion para cambiar estado del monitor
    public void setIsActive(bool _state)
    {
        cameras[currentCamera].SetActive(_state);
        camerasPanel.SetActive(_state);
        if (_state)
        {
            monitorAS.Play();
            EnergyManager.Instance.increaseConsumptionLevel();
        }
        else
        {
            monitorAS.Stop();
            EnergyManager.Instance.decreaseConsumptionLevel();
        }

        //Music Box
        if (currentCamera == 2)
        {
            MusicBox.Instance.SetStateUI(true);
        }
    }
}
