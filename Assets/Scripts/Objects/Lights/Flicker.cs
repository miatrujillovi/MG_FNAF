using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    //Variables Publicas
    public float minFlickInterval, maxFlickInterval;
    public float minLightIntensity;
    public float minFlickDuration, maxFlickDuration;

    //Variables Privadas
    private Light lightcomponent;
    private float intervalTime, originalLightIntensity;
    private float flickDuration;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializacion de Variables
        lightcomponent = GetComponent<Light>();
        originalLightIntensity = lightcomponent.intensity;
        intervalTime = Random.Range(minFlickInterval, maxFlickInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    //Funcion de Parpadeo
    void Flick()
    {
        if (intervalTime <= 0f)
        {
            lightcomponent.intensity = Random.Range(minLightIntensity, originalLightIntensity);
            intervalTime = Random.Range(minFlickInterval, maxFlickInterval);
            flickDuration = Random.Range(minFlickDuration, maxFlickDuration);
        } else
        {
            if (flickDuration > 0f)
            {
                flickDuration -= 1f * Time.deltaTime;
            } else
            {
                intervalTime -= 1f * Time.deltaTime;
                lightcomponent.intensity = originalLightIntensity;
            }
        }
    }
}
