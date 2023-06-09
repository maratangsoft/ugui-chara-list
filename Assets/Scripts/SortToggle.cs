using UnityEngine;
using UnityEngine.UI;

public class SortToggle : MonoBehaviour
{
	public Image buttonImage;

    public void ChangeIcon()
	{
        if (GetComponent<Toggle>().isOn)
            buttonImage.sprite = Resources.Load<Sprite>("Icons/triangle-down");
        else
            buttonImage.sprite = Resources.Load<Sprite>("Icons/triangle-up");
    }
}
