using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DebugWeatherUIController : MonoBehaviour
{
    [Header("Scriptable Object")]
    [SerializeField]private BatteryDisplayData batteryDisplayData;

    [Header("Slider")]
    [SerializeField] private Slider intensitySlide;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI beforeValue;
    [SerializeField] private TextMeshProUGUI afterValue;

    [Header("Parent")]
    [SerializeField] private GameObject mainPanel;

    [Header("prefab Notification")]
    [SerializeField] private GameObject notificationPrefab;

    float intensity;
    int hour;
    int duration;

    public void InputDataToWeatherController()
    {
        if (int.Parse(beforeValue.text) <= int.Parse(afterValue.text))
        {
            float intensity = intensitySlide.value;
            int before = int.Parse(beforeValue.text);
            int after = int.Parse(afterValue.text);
            CreateData(intensity, before, after);
            string message = "Akan " + (intensity > 0.7f ? "hujan" : "berawan") + " pada jam " + beforeValue.text + " sampai dengan " + afterValue.text;
            CreateNotificator(0, message);
        }
        else
        {
            string message = "Waktu sebelum hujan tidak boleh kurang dari waktu hujan";
            CreateNotificator(1, message);            
        }
    }

    public void RandomDataToWeatherController()
    {
        RandomizeData();
        float intensity = intensitySlide.value;
        int before = int.Parse(beforeValue.text);
        int after = int.Parse(afterValue.text);
        CreateData(intensity, before, after);
        string message = "Akan " + (intensity > 0.7f ? "hujan" : "berawan") + " pada jam " + beforeValue.text + " sampai dengan " + afterValue.text;
        CreateNotificator(0, message);
    }
    void RandomizeData()
    {
        intensitySlide.value = Random.Range(0f, 1f);
        int beforeAndAfterCounter = Random.Range(6, 15);
        beforeValue.text = beforeAndAfterCounter.ToString();
        afterValue.text = (beforeAndAfterCounter + Random.Range(1, 3)).ToString();
    }
    void CreateData(float intensity, int before, int after)
    {
            intensity = intensitySlide.value;
            for (int i = before; i < after; i++)
            {
                batteryDisplayData.listInput[i] = Mathf.Lerp(BatteryEletricalReceiver.instance.solarPanelMaximumWatt, BatteryEletricalReceiver.instance.solarPanelMaximumWatt/2, intensity);
            }
            BatteryEletricalReceiver.instance.ChangeInputBattery();
            StartCoroutine(WeatherController.instance.GenerateWeather());
    }

    void CreateNotificator(int condition, string message)
    {
        gameObject.Instantiate(notificationPrefab, mainPanel.transform.position, mainPanel.transform.rotation, mainPanel.transform.parent, condition, message);
        
    }
}
