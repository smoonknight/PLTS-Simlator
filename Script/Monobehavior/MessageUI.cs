using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    public static MessageUI instance {get; private set;}
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
    }

    private void Start()
    {
        MessageDisplayData.Clear();
    }

    [SerializeField] private TextMeshProUGUI textMessage;

    public void UpdateChangedMessageDisplayData()
    {
        textMessage.text = MessageDisplayData.modifierMessage;
    }
}
