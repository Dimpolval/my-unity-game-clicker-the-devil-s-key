using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    [SerializeField] private NumberView _view;

    [SerializeField] private int _loverBound = 0;

    [SerializeField] private int _upperBound = 9;

    [SerializeField] private int _lockValue;

    [SerializeField] private int _unlockValue;

    private int _value;
    public bool IsUnlocked => _value == _unlockValue;
    public void Lock()
    {
        SetAndDisplay(_lockValue);
    }
    public void Change(int amount)
    {
        int newValue = _value + amount;
        SetAndDisplay(newValue);
    }
    private void SetAndDisplay(int newValue)
    {
        NormalizeAndSet(newValue);
        DisplayValue();
    }
    private void NormalizeAndSet(int newValue)
    {
        _value = Normalize(newValue);
    }
    private int Normalize(int value)
    {
        if (value > _upperBound)
        {
            int outBoundValue = value - _upperBound;
            outBoundValue -= 1;
            value = _loverBound + outBoundValue;
        }
        else if (value < _loverBound)
        {
            int outBoundValue = value - _loverBound;
            outBoundValue += 1;
            value = _upperBound + outBoundValue;
        }
        return value;
    }
    private void DisplayValue()
    {
        _view.Display(_value);
    }
}
