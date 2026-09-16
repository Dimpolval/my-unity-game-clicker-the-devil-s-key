using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TimerView _view;

    [SerializeField] private float _timeLimit = 30f;

    [SerializeField] private float _condownInterval = 1.0f;

    [SerializeField] private UnityEvent _timerFinished;

    private Coroutine _coroutine;
    public float TimeLimit => _timeLimit;
    public bool IsTimerRunning => _coroutine != null;
    public void Stop()
    {
        StopCoroutineIfActive();
    }
    public void Restart()
    {
        StopCoroutineIfActive();
        StartNewCoroutine();
    }
    private void StopCoroutineIfActive()
    {
        if (IsTimerRunning)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }
    private void StartNewCoroutine()
    {
        _coroutine = StartCoroutine(CountdownTime(_timeLimit, _condownInterval));
    }
    private IEnumerator CountdownTime(float timeLimit, float interval)
    {
        float remainingTime = timeLimit;
        WaitForSeconds waitInterval = new WaitForSeconds(interval);
        DisplayTime(timeLimit, remainingTime);
        do
        {
            yield return waitInterval;
            remainingTime = Mathf.Max(remainingTime - interval, 0f);
            DisplayTime(timeLimit, remainingTime);
        }
        while (remainingTime > 0);
        _coroutine = null;
        _timerFinished.Invoke();
    }
    private void DisplayTime(float timeLimit, float time)
    {
        _view.Display(timeLimit, time);
    }
}
