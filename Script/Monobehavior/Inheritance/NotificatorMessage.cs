using UnityEngine;

public class NotificatorMessage : MonoBehaviour
{
    public void SetMessageDisplay(string from, string message)
    {
        MessageDisplayData.modifierMessage = DayNightController.instance.currentTime.ToString("HH:mm") + " " + from + " : " + message;
    }

    public void ClearMessageDisplay()
    {
        MessageDisplayData.Clear();
    }
}