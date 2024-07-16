using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicBox : MonoBehaviour
{
    //Variables Publicas
    public UnityEvent OnOpened, OnWindUp;
    public GameObject musicBoxPanel, warningIcon;
    public Image fillerImage;

    //Variables Privadas
    [SerializeField] private float fill, windUpCooldownTime, fillPerWindUp, consumptionRate, warningLevel;
    private bool isActive, isOpen, canWindUp;

    //Singleton
    public static MusicBox Instance { get; private set; }

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
        fill = 1f;
        canWindUp = true;
        isOpen = false;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Si el panel esta activado entonces actualizamos la UI
        if (musicBoxPanel.activeSelf)
        {
            UpdateUI();
        }

        //Si la caja esta activa y aun no esta abierta entonces consumimos
        if (isActive && !isOpen)
        {
            Consumption();
        }
    }

    //Funcion de Consumo
    public void Consumption()
    {
        fill -= consumptionRate * Time.deltaTime;
        //Advertencia
        if (fill <= warningLevel)
        {
            warningIcon.SetActive(true);
        }
        else
        {
            warningIcon.SetActive(false);
        }

        //Si el fill llega a 0 entonces abrimos la caja
        if (fill <= 0f)
        {
            warningIcon.SetActive(true);
            isOpen = true;
            OnOpened.Invoke();
        }
    }

    //Funcion para activar o desactivar la UI
    public void SetStateUI(bool _state)
    {
        musicBoxPanel.SetActive(_state);
    }

    //Funcion par actualizar la UI
    public void UpdateUI()
    {
        fillerImage.fillAmount = fill;
    }

    //Funcion para activar o desactivar Caja de Musica
    public void SetIsActive(bool _state)
    {
        isActive = _state;
    }

    //Funcion para darle Cuerda a la Caja de Musica
    public void WindUpMusicBox()
    {
        //Si la caja esta activa pero no abierta
        if (isActive && !isOpen)
        {
            if (canWindUp)
            {
                fill += fillPerWindUp;
                fill = Mathf.Clamp(fill, 0f, 1f);
                OnWindUp.Invoke();
                StartCoroutine(ButtonCooldown());
            }
        }
    }

    //Corrutina para el cooldown del boton
    IEnumerator ButtonCooldown()
    {
        canWindUp = false;
        yield return new WaitForSeconds(windUpCooldownTime);
        canWindUp = true;
    }
}
