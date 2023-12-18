using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BobController _bobController;
    [SerializeField] private GameObject _endScreen;


    private void OnEnable()
    {
        _bobController.OnKilled += BobControllerOnKilled;
    }

    private void OnDisable()
    {
        _bobController.OnKilled += BobControllerOnKilled;
    }

    private void BobControllerOnKilled()
    {
        _endScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
