using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    //Variables Publicas
    public int numHours, secPerHour;
    public Text timerText;
    public GameObject losePanel;
    public UnityEvent GameOver, Win, Lose;

    //Variables Privadas
    private int time;

    //Singleton
    public static LevelManager Instance { get; private set; }

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
        time = 0;
        timerText.text = time + ":00";
        InvokeRepeating("UpdateTime", secPerHour, secPerHour);
    }

    //Funcion para cambiar la hora 
    void UpdateTime()
    {
        time++;
        timerText.text = time + ":00";
        if (time == 6){
            GameOver.Invoke();
            Win.Invoke();
        }
    }

    // Jugador Muerto
    public void PlayerDead()
    {
        StartCoroutine(JumpscareCoroutine());
    }

    //Corrutina para perder (Jumpscare)
    IEnumerator JumpscareCoroutine()
    {
        GameOver.Invoke();
        Lose.Invoke();
        yield return new WaitForSeconds(1.5f);
        losePanel.SetActive(true);
    }
}
