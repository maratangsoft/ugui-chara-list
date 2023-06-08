using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FilterToggle : MonoBehaviour
{
    public TMP_Text text;

    public void ChangeColor()
    {
        if (GetComponent<Toggle>().isOn)
        {
            GetComponent<Image>().color = new Color32(97, 97, 97, 255);
            text.color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
            text.color = Color.black;
        }
    }
}
