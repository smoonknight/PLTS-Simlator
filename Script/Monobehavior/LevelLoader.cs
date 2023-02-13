using System.Net.Mime;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    #region Singleton
    public static LevelLoader instance {get; private set;}

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    #endregion

    [SerializeField] private Animator transition;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingProgress;
    [SerializeField] private TextMeshProUGUI loadingText;

    public void Start()
    {
        Time.timeScale = 1f;
    }
    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName)
    {
        Time.timeScale = 1f;
        loadingText.text = "0%";
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01((operation.progress / .9f)/2);
            
            loadingProgress.fillAmount = progress;
            loadingText.text = $"{Mathf.Floor(progress) * 100}%";
            yield return null;
        }
    }
}
