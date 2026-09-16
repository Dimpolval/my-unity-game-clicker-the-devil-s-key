using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;

    public void Display(int number)
    {
        _textField.text = $"{number}";
    }
}
