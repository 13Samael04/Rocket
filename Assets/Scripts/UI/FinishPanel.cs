using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class FinishPanel : MonoBehaviour
{
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private AudioClip _finishSound;
    [SerializeField] private Image _win;
    [SerializeField] private Player _player;
    
    private AudioSource _audioSource;

    private void OnEnable()
    {
        _player.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _player.Finished -= OnFinished;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnFinished()
    {
        _finishPanel.SetActive(true);
        _audioSource.PlayOneShot(_finishSound);
        StartCoroutine(IncreaseScaleImageWin());
        Time.timeScale = 0;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void SetNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentSceneIndex);
    }

    private IEnumerator IncreaseScaleImageWin()
    {
        var AlfaChanal = _win.color;

        for (int i = 255; i > 0; i--)
        {
            AlfaChanal.a = 1f - (1f / 255f * i);
            _win.color = AlfaChanal;
            yield return null;
        }
    }
}
