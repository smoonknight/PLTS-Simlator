using UnityEngine;

public class MessageDisplayData
{
    public static string modifierMessage
    {
        get
        {
            return message;
        }
        set
        {
            message += value + "\n";
            MessageUI.instance.UpdateChangedMessageDisplayData();
        }
    }

    public static string message;

    public static void Clear()
    {
        message = "";
    }
}