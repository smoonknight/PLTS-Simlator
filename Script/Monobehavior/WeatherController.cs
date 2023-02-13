using System.Security.Cryptography;
using UnityEngine;
using System.Collections;

public class WeatherController : NotificatorMessage
{
    public static WeatherController instance {get; private set;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
    }

    float modifierCloudRateOverTime 
    {
        get 
        {
            return cloudRate; 
        } 
        set 
        {
            lastCloudRate = cloudRate;
            cloudRate = value;

        }
    }

    float modifierRainRateOverTime
    {
        get
        {
            return rainRate;
        }
        set
        {
            lastRainRate = rainRate;
            rainRate = value;
        }
    }

    float modifierValueWeather
    {
        get
        {
            return valueWeather;
        }
        set
        {
            lastValueWeather = valueWeather;
            valueWeather = value;
        }
    }

    [Header("Particle")]
    [SerializeField] private ParticleSystem cloud;
    [SerializeField] private ParticleSystem rain;

    [Header("Material")]
    [SerializeField] private Material cloudMaterial;

    float cloudRateOverTime;
    float RainRateOverTime;
    float lastCloudRate;
    float lastRainRate;
    float lastValueWeather;
    float cloudRate;
    float rainRate;
    float valueWeather;
    float timeUntilWeather;
    float rainyRate = 0.7f;
    float rainyStrongRate = 0.85f;
    float elapsedTime = 0.1f;
    private void Start() 
    {
        cloudRateOverTime = 10;
        RainRateOverTime = 900;
    }

    IEnumerator SetWeather()
    {
        while (elapsedTime <= 1f)
        {    
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;

            var newCloud = cloud.emission;
            var newRain = rain.emission;

            newCloud.rateOverTimeMultiplier = Mathf.Lerp(lastCloudRate, modifierCloudRateOverTime, elapsedTime);
            cloudMaterial.color = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(lastValueWeather, modifierValueWeather, elapsedTime));
            newRain.rateOverTimeMultiplier = Mathf.Lerp(lastRainRate, modifierRainRateOverTime, elapsedTime);
        }
    }

    public IEnumerator GenerateWeather()
    {
        yield return new WaitForSeconds(1);

        string audioName;

        elapsedTime = 0;
        float batteryResult = BatteryEletricalReceiver.instance.inputBattery/BatteryEletricalReceiver.instance.solarPanelMaximumWatt;
        float intensity = batteryResult == 0 
            ? Random.Range(0f, 1f) 
            : MathSolve.MathPercentage(batteryResult);

        modifierValueWeather = Mathf.Lerp(1f, 0f, intensity);
        modifierCloudRateOverTime = Mathf.Lerp(0, cloudRateOverTime, modifierValueWeather);
        if (modifierValueWeather > rainyRate)
        {
            modifierRainRateOverTime = Mathf.Lerp(0, RainRateOverTime, modifierValueWeather);
            audioName = (modifierValueWeather > rainyStrongRate ? "Ambiance_RainStrong" : "Ambiance_RainCalm");
            AudioManager.instance.Play(audioName, true);
        }
        else
        {
            modifierRainRateOverTime = 0;
            AudioManager.instance.Stop("Ambiance_RainStrong", true);
            AudioManager.instance.Stop("Ambiance_RainCalm", true);
        }

        StartCoroutine(SetWeather());
        string message = "Cuaca saat ini " + (modifierRainRateOverTime == 0 ? "berawan" : "hujan");
        SetMessageDisplay("WeatherCast", message);
    }
}
