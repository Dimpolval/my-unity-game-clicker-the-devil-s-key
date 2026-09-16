using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
        
    public void Display(float timeLimit, float time)
    {
        _textField.text = $"{time:00}";
    }
}
