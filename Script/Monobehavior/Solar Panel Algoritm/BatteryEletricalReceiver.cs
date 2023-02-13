using System.Collections;
using UnityEngine;

public class BatteryEletricalReceiver : NotificatorMessage
{
    public static BatteryEletricalReceiver instance{get; private set;}
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [Header("Scriptable Object")]
    public SolarPanelData solarPanelData;
    public BatteryData batteryData;
    [SerializeField] private BatteryDisplayData batteryDisplayData;
    [SerializeField] private DateAndTimeDisplayData dateAndTimeDisplayData;
    [Header("Monobehavior")]
    [SerializeField] private DayNightController dayNightController;
    [Header("Light")]
    [SerializeField] private Light intensityLight;

    int checkHour;
    float inputBatteryHelper;
    float outputBatteryHelper;
    float voltBattery;
    float ampereBattery;
    float wattBatteryCapacity;
    float solarPanelMaximumVolt;
    float solarPanelMaximumAmpere;

    
    public string nameBattery;
    public string solarPanelName;
    public float solarPanelMaximumWatt;

    public float inputBattery;
    public void OnStart()
    {

        ValidateBatteryInformation();
        GetPanelSuryaDescription(solarPanelData.maximumVolt, solarPanelData.maximumAmpere, solarPanelData.maximumWatt, solarPanelData.name);
        CleanState();
    }

    void OnEnable()
    {
        StartCoroutine(UpdateStatusEverySecond());
    }
    IEnumerator UpdateStatusEverySecond() 
    {
        while (true)
        {
            UpdateInputAndOutputBatteryToCurrentBattery();
            AddBatteryInformationToFloatBatteryData();
            yield return new WaitForSeconds(1);
        }
    }

    void UpdateInputAndOutputBatteryToCurrentBattery()
    {
        inputBatteryHelper = Mathf.Lerp(0, inputBattery, 0.05f);
        batteryData.currentBattery += inputBatteryHelper;

        outputBatteryHelper = Mathf.Lerp(0, batteryData.outputBattery, 0.05f);
        batteryData.currentBattery -= outputBatteryHelper;

        batteryData.currentBattery = Mathf.Clamp(batteryData.currentBattery, 0, wattBatteryCapacity);
    }

    public void CleanState()
    {
        batteryData.clear();

        batteryDisplayData.clear();
    }

    public BatteryData GetBatteryData()
    {
        return batteryData;
    }

    void ValidateBatteryInformation()
    {
        nameBattery = batteryData.name;
        voltBattery = batteryData.voltBattery;
        ampereBattery = batteryData.ampereBattery;
        wattBatteryCapacity = (ampereBattery * voltBattery);
    }

    public void GetPanelSuryaDescription(float maximumVolt, float maximumAmpere, float maximumWatt, string name)
    {
        solarPanelMaximumVolt = maximumVolt;
        solarPanelMaximumAmpere = maximumAmpere;
        solarPanelMaximumWatt = maximumWatt;
        solarPanelName = name;
        string message = $"Panel surya yang digunakan adalah {solarPanelName}";
        SetMessageDisplay("MoonIoT", message);
    }

    public void UpdateHour()
    {
        RevalidationCurrentBattery(inputBattery);
        ChangeInputBattery();
        AddBatteryInformationToListBatteryData();
    }

    public void ChangeInputBattery()
    {
        inputBattery = batteryDisplayData.listInput[DayNightController.instance.currentTime.Hour + 1];
    }

    private void AddBatteryInformationToListBatteryData()
    {
        batteryDisplayData.listOutput[DayNightController.instance.currentTime.Hour] = batteryData.outputBattery;
        batteryDisplayData.listCurrent[DayNightController.instance.currentTime.Hour] = batteryData.lastHourCurrentBattery;
    }

    private void AddBatteryInformationToFloatBatteryData()
    {
        batteryDisplayData.currentUsage = batteryData.currentBattery.ToString();
        batteryDisplayData.outputUsage = batteryData.outputBattery.ToString("f2");
        batteryDisplayData.inputUsage = inputBattery.ToString("f2");
    }


    public void RevalidationCurrentBattery(float inputData)
    {
        float currentbatteryState = batteryData.lastHourCurrentBattery + inputData - batteryData.outputBattery;
            
        batteryData.currentBattery = Mathf.Clamp(currentbatteryState, 0, wattBatteryCapacity);
        batteryData.lastHourCurrentBattery = batteryData.currentBattery;
    }
}
