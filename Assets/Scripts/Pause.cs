using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pauseWindow;
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        _playerMove.Pause();
        _coinSpawner.Pause();
        _pauseWindow.SetActive(true);
        _pauseButton.interactable = false;
    }
    
    public void Resume()
    {
        Time.timeScale = 1;
        _playerMove.Resume();
        _coinSpawner.Resume();
        _pauseWindow.SetActive(false);
        _pauseButton.interactable = true;
    }
}