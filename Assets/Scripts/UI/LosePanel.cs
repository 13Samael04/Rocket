using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _losePanel;

    private void OnEnable()
    {
        _player.Died += OpenPanel;
    }

    private void OnDisable()
    {
        _player.Died -= OpenPanel;
    }

    public void OpenPanel()
    {
        _losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
