
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateData : MonoBehaviour
{
    public static UpdateData instance {get; private set;}

    void Awake()
    {
        if (instance == null)
            instance = this;

        else
            Destroy(gameObject);
    }

    int pastHour;
    bool isEndgame;

    private void Start() 
    {
        FirstLaunch();
    }
    private void FixedUpdate() 
    {
        CallWhenTime(0);
        CheckTimeEveryHour();
    }

    private void CallWhenTime(int time)
    {
        if (isEndgame)
        {
            return;
        }
        if (isTimeEqualToCurrentTime(time))
        {
            isEndgame = true;
            LevelLoader.instance.LoadNextLevel("EndgameScene");
        }
    }

    private void CheckTimeEveryHour()
    {
        if (isEndgame)
        {
            return;
        }
        if (!isTimeEqualToCurrentTime(pastHour))
        {
            int hourNow = DayNightController.instance.currentTime.Hour;
            Revalidate();
            pastHour = hourNow;
        }
    }
    private bool isTimeEqualToCurrentTime(int time)
    {
        if (DayNightController.instance.currentTime.Hour != time)
        {
            return false;
        }
        return true;
    }

    public void Revalidate()
    {
        BatteryEletricalReceiver.instance.UpdateHour();
        DayNightController.instance.UpdateHour();
        UsageManager.instance.UpdateHour();
        StartCoroutine(WeatherController.instance.GenerateWeather());
    }

    public void FirstLaunch()
    {
        AudioManager.instance.StopAll();
        UsageManager.instance.OnStart();
        DayNightController.instance.ValidateDay();
        BatteryEletricalReceiver.instance.OnStart();
        AudioManager.instance.Play("Ambiance_WindForest", true);
    }
    
}
