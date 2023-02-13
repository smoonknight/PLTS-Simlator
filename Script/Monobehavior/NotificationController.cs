using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class ExtensionMethod
{
    public static UnityEngine.Object Instantiate(this UnityEngine.Object thisObj, UnityEngine.Object original, Vector3 position, Quaternion rotation, Transform parent, int condition, string message)
    {
        GameObject notificator = UnityEngine.Object.Instantiate(original, position, rotation, parent) as GameObject;
        NotificationController notificationController = notificator.GetComponent<NotificationController>();
        notificationController.NotificationSetup(condition, message);
        notificationController.SetMessageDisplay("WeatherSetter",message);
        return notificator;
    }
}
public class NotificationController : NotificatorMessage
{
    [Header("Sprite")]
    [SerializeField] private Sprite successIcon;
    [SerializeField] private Sprite errorIcon;

    [Header("Image")]
    [SerializeField] private Image iconImage;
    [SerializeField] private Image notificationPanel;
    [Header("TMPro Text")]
    [SerializeField] private TextMeshProUGUI conditionText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    Dictionary<int, NotificationConditionValue> notificationCondition = new Dictionary<int, NotificationConditionValue>();
    
    class NotificationConditionValue
    {
        public Sprite icon {get; set;}
        public String text {get; set;}
        public Color color {get; set;}
    }
    void Awake()
    {
        notificationCondition.Add(0, new NotificationConditionValue(){icon = successIcon, text = "Success", color = new Color32(46, 204, 113, 255)});
        notificationCondition.Add(1, new NotificationConditionValue(){icon = errorIcon, text = "Error", color = new Color32(214, 48, 49, 255)});
        PopupNotificationAnimate();
        AudioManager.instance.Play("SFX_Notification");
        StartCoroutine(CloseGameObject());
    }

    IEnumerator CloseGameObject()
    {
        yield return new WaitForSeconds(3);
        CloseNotificationAnimate();
    }
    void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(0, 275);
        gameObject.transform.localScale = Vector2.zero;
        
        gameObject.transform.LeanMoveLocal(new Vector2(0, 175), 0.3f);
        gameObject.LeanScale(Vector2.one, 0.3f);
    }

    void OnDisable()
    {
        Destroy(gameObject);
    }

    void PopupNotificationAnimate()
    {
        gameObject.transform.localPosition = new Vector2(0, 275);
        gameObject.transform.localScale = Vector2.zero;
        
        gameObject.transform.LeanMoveLocal(new Vector2(0, 175), 0.3f).setEaseInQuart();
        gameObject.LeanScale(Vector2.one, 0.3f).setEaseInQuart();
    }

    

    void CloseNotificationAnimate()
    {
        gameObject.transform.LeanMoveLocal(new Vector2(0, 275), 0.3f).setEaseInQuart();
        gameObject.LeanScale(Vector2.zero, 0.3f).setEaseInQuart().setOnComplete(new System.Action(() => Destroy(gameObject)));
    }
    public void NotificationSetup(int condition = 0, string description = "Berhasil")
    {
        iconImage.sprite = notificationCondition[condition].icon;
        conditionText.text = notificationCondition[condition].text;
        descriptionText.text = description;
        notificationPanel.color = notificationCondition[condition].color;
    }
}
