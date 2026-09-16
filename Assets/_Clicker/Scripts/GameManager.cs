using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuScreen;

    [SerializeField] private GameObject _gamePlayScreen;

    [SerializeField] private GameObject _playerWinScreen;

    [SerializeField] private GameObject _playerLoseScreen;

    [SerializeField] private Timer _timer;

    [SerializeField] private Lock _lock;

    private void Start()
    {
        SwitchToMainMenuScreen();
    }
    public void OnStartNewGame()
    {
        SwitchToGamePlayScreen();
        LockUpAndStartTimer();
    }
    public void OnPlayerWon()
    {
        StartCoroutine(DelayedWinScreen());
    }
    private IEnumerator DelayedWinScreen()
    {
        StopTimer();
        yield return new WaitForSeconds(1f);
        SwitchToPlayerWinScreen();
    }
    public void OnPlayerLost()
    {
        StartCoroutine(DelayedLoseScreen());
    }
    private IEnumerator DelayedLoseScreen()
    {
        yield return new WaitForSeconds(1f);
        SwitchToPlayerLoseScreen();
    }
    public void OnBackToMainMenu()
    {
        SwitchToMainMenuScreen();
    }
    private void LockUpAndStartTimer()
    {
        _lock.Lockup();
        _timer.Restart();
    }
    private void StopTimer()
    {
        _timer.Stop();
    }
    private void SwitchToMainMenuScreen()
    {
        _mainMenuScreen.SetActive(true);
        _gamePlayScreen.SetActive(false);
        _playerWinScreen.SetActive(false);
        _playerLoseScreen.SetActive(false);
    }
    private void SwitchToGamePlayScreen()
    {
        _gamePlayScreen.SetActive(true);
        _mainMenuScreen.SetActive(false);
    }
    private void SwitchToPlayerWinScreen()
    {
        _playerWinScreen.SetActive(true);
        _gamePlayScreen.SetActive(false);
    }
    private void SwitchToPlayerLoseScreen()
    {
        _playerLoseScreen.SetActive(true);
        _gamePlayScreen.SetActive(false);
    }
}
