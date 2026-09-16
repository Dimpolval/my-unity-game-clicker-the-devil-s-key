using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    [SerializeField] private Number _number1;

    [SerializeField] private Number _number2;

    [SerializeField] private Number _number3;

    [SerializeField] private UnityEvent _doorUnlocked;
            
    public bool IsUnlocked => _number1.IsUnlocked && _number2.IsUnlocked && _number3.IsUnlocked;
    public void Lockup()
    {
        _number1.Lock();
        _number2.Lock();
        _number3.Lock();
    }
    public void ChangeCombination(int amount1, int amount2, int amount3)
    {
        ChangeNumbers(amount1, amount2, amount3);
        NotifyIfUnlocked();
    }
    private void NotifyIfUnlocked()
    {
        if (IsUnlocked)
        {
             _doorUnlocked.Invoke();
        }
    }
    private void ChangeNumbers(int amount1, int amount2, int amount3)
    {
        _number1.Change(amount1);
        _number2.Change(amount2);
        _number3.Change(amount3);
    }
}
