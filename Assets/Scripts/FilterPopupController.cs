using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FilterPopupController : MonoBehaviour
{
    public Toggle[] toggles;
    [SerializeField]
    public UnityEvent OnConfirmed;

    private bool[] toggleValues = {true, true, true, true, true, true};

    public bool[] ToggleValues { get => toggleValues; }

    public void ResetToggleValues()
    {
        foreach (var toggle in toggles)
        {
            toggle.isOn = false;
            toggle.GetComponent<FilterToggle>().ChangeColor();
        }
    }

    public void Confirm()
    {
        toggleValues = new bool[6];
        for (int i = 0; i < toggles.Length; i++)
        {
            toggleValues[i] = toggles[i].isOn;
        }
        Close();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        OnConfirmed.Invoke();
    }
}
