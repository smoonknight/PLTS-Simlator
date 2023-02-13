
using UnityEngine;

public class TransitionUIController : MonoBehaviour
{
    Vector2 vector2;
    
    void Awake()
    {
        vector2 = gameObject.GetComponent<Transform>().localScale;
    }
    void OnEnable()
    {
        AudioManager.instance.Play("SFX_FadeIn");
        LeanTween.cancel(gameObject);
        
        gameObject.transform.localScale = new Vector2(0, 0);
        gameObject.LeanScale(vector2, 0.2f).setEaseOutQuart();
    }

    public void DisableGameObject()
    {
        AudioManager.instance.Play("SFX_FadeOut");
        LeanTween.cancel(gameObject);
        gameObject.LeanScale(Vector3.zero, 0.2f).setEaseOutQuart().setOnComplete(new System.Action(() => gameObject.SetActive(false)));
    }
}
