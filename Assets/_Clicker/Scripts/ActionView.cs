using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameField;

    [SerializeField] private TMP_Text _effectField;

    public void DisplayName(string name)
    {
        _nameField.text = name;
    }
    public void DisplayInfo(int amount1, int amount2, int amount3)
    {
        _effectField.text = $"{amount1} | {amount2} | {amount3}";
    }
}
