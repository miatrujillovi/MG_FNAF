using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    //Variables Publicas
    public float energy, consumptionRate;
    public UnityEvent onDischarged;

    public Image usageFiller;
    public Text PowerLeftText;

    //Variables Privadas
    private int consumptionLevel;
    private bool isDischarged;

    //Singleton
    public static EnergyManager Instance { get; private set; }

    private void Awake()
    {
        //Verificacion del Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de Variables
        consumptionLevel = 0;
        isDischarged = false;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        //Si no estamos descargando
        if (!isDischarged)
        {
            Consumption();
        }
    }

    void Consumption()
    {
        if (energy > 0f)
        {
            energy -= consumptionRate * consumptionLevel * Time.deltaTime;
            UpdateUI();
        } else
        {
            UpdateUI();
            isDischarged=true;
            onDischarged.Invoke();
        }
    }

    public void increaseConsumptionLevel()
    {
        consumptionLevel++;
    }

    public void decreaseConsumptionLevel()
    {
        consumptionLevel--;
    }

    public void UpdateUI()
    {
        PowerLeftText.text = (int)energy + "%";
        usageFiller.fillAmount = consumptionLevel / 5f;
    }
}

