using System.IO;
using System.Collections;
using UnityEngine;
using TMPro;

public class PanelMonitoring : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject rowContainer;

    [SerializeField] private BatteryDisplayData batteryDisplayData;

    [SerializeField] private int valueToCheck = 0;

    private void OnEnable()
    {
        if (content.childCount != 0)
        {
            DeleteTable();
        }
        StartCoroutine(GenerateTable());
    }
    public IEnumerator GenerateTable()
    {
        yield return new WaitForSeconds(1);

        int hour = valueToCheck == 0 ? DayNightController.instance.currentTime.Hour : valueToCheck;
        
        for (int i = 0; i <= hour; i++)
        {
            GameObject row = Instantiate(rowContainer, content);

            TextMeshProUGUI[] textMeshProUGUIs = row.GetComponentsInChildren<TextMeshProUGUI>();
            
            textMeshProUGUIs[0].text = i.ToString();
            textMeshProUGUIs[1].text = batteryDisplayData.listInput[i].ToString();
            textMeshProUGUIs[2].text = batteryDisplayData.listOutput[i].ToString();
            textMeshProUGUIs[3].text = batteryDisplayData.listCurrent[i].ToString();
        }
    }

    public void DeleteTable()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Transform childTransform = content.GetChild(i);

            Destroy(childTransform.gameObject);
        }
    }
}
