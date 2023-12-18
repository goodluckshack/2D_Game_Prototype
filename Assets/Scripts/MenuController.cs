using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Image _loader;
    [SerializeField] private CanvasGroup _canvasGroup;

    void Start()
    {
        _loader.fillAmount = 0;
        _canvasGroup.alpha = 0;
    }

    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene() 
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);

        while (!asyncOperation.isDone)
        {
            _canvasGroup.alpha += Time.deltaTime;
            _loader.fillAmount = asyncOperation.progress * 100;

            yield return null;
        }
    }
}
