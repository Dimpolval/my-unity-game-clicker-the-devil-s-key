using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] private ActionView _view;

    [SerializeField] private Lock _lock;

    [SerializeField] private string _name;

    [SerializeField, Range(-3, 3)] private int _amount1;

    [SerializeField, Range(-3, 3)] private int _amount2;

    [SerializeField, Range(-3, 3)] private int _amount3;

    private void Start()
    {
        _view.DisplayName(_name);
        _view.DisplayInfo(_amount1, _amount2, _amount3);
    }
    public void OnClickButton()
    {
        _lock.ChangeCombination(_amount1, _amount2, _amount3);
    }
}
