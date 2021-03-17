using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;

    private void Start()
    {
        _pauseCanvas.gameObject.SetActive(false);
    }

    public void Pause()
    {
        _pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        _pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
