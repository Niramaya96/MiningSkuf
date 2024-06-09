using UnityEngine;
using TMPro;
using Lessons;
using System;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _woodValue;
    [SerializeField] private TMP_Text _ironValue;
    [SerializeField] private TMP_Text _stoneValue;

    public void ChangeResourceValueDisplay(ResourceType resourseType,int value)
    {
        switch (resourseType)
        {
            case ResourceType.Wood:
                _woodValue.text = value.ToString();
                break;
            case ResourceType.Stone:
                _stoneValue.text = value.ToString();
                break;
            case ResourceType.Iron:
                _ironValue.text = value.ToString();
                break;
        }
    }

    private void Start()
    {
        SetStartValues();
    }

    private void SetStartValues()
    {
        var resText = new[] { _woodValue, _ironValue, _stoneValue };

        foreach (var item in resText)
        {
            item.text = 0.ToString();
        }
    }
}
