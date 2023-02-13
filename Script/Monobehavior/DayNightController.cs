using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class DayNightController : MonoBehaviour
{
    public static DayNightController instance {get; private set;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        StartCoroutine(UpdateStatusEverySecond());
    }

    [Header("Scriptable Oject")]
    [SerializeField] private DateAndTimeDisplayData dateAndTimeDisplayData;
    [Header("Monobehavior")]
    [Header("Light")]
    [SerializeField] private Light sunLight;
    [Header("Hour Event")]
    [SerializeField] private float startHour;
    [SerializeField] private float sunriseHour;
    [SerializeField] private float sunsetHour;
    [Header("Maximum Intensity")]
    [SerializeField] private float maxSunLightIntensify;
    [Header("Color of Ambient")]
    [SerializeField] private Color dayAmbientLight;
    [SerializeField] private Color nightAmbientLight;
    [Header("Curve and Multiplier Time")]
    [SerializeField] private AnimationCurve lightChangeCurve;
    [SerializeField] private float timeMultiplier;

    
    string modifierAudioName
    {
        get
        {
            return audioName;
        }
        set
        {
            pastAudioName = audioName;
            audioName = value;
        }
    }

    string pastAudioName;
    string audioName;


    private TimeSpan sunriseTime;
    private TimeSpan sunsetTime;

    float sunLightRotation;

    private int checkHour;

    [NonSerialized] public DateTime currentTime;
    [NonSerialized] public float intensityModifier;
    [NonSerialized] public float modifierIntensity;
    [NonSerialized] public float multipleTime;
    [NonSerialized] public string resultTime;
    [NonSerialized] public string resultDay;

    IEnumerator UpdateStatusEverySecond() 
    {
        while (true)
        {
            UpdateLightSettings();
            UpdateDateAndTimeDisplayInformation();
            yield return new WaitForSeconds(1);
        }
    }

    void Update()
    {
        updateDateAndTimeOfDay();
        RotateSun();
    }

    public void ValidateDay()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
        UpdateDateAndTimeDisplayInformation();
    }
    
    private void UpdateDateAndTimeDisplayInformation()
    {
        dateAndTimeDisplayData.time = currentTime.ToString("HH:mm");
        dateAndTimeDisplayData.day = currentTime.ToString("MMM dd");
        dateAndTimeDisplayData.hourInElapse = (float)currentTime.Minute / 60;
    }
    private void updateDateAndTimeOfDay()
    {
        multipleTime = Time.deltaTime * timeMultiplier;
        currentTime = currentTime.AddSeconds(multipleTime);
    }

    private void RotateSun()
    {
        if(currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(0, 180, (float)percentage);
        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(180, 360, (float)percentage);
        }

        transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(transform.forward, Vector3.down);
        sunLight.intensity =  Mathf.Lerp(0, maxSunLightIntensify,lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct)));
    }

    public void UpdateHour()
    {
        AmbianceAudioUsageByHour();
    }

    void AmbianceAudioUsageByHour()
    {
        if (sunLightRotation > 180)
        {
            AudioManager.instance.Play("Ambiance_Night", true);
        }
        else
        {
            AudioManager.instance.Stop("Ambiance_Night", true);
        }
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
        if(difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}
