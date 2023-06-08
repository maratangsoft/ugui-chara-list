using System;
using UnityEngine;
using UnityEngine.UI;

public class SortToggle : MonoBehaviour
{
	public Image buttonImage;
	public bool isOn = true;

	public void OnClick()
	{
		if (isOn)
		{
			isOn = false;
			buttonImage.sprite = Resources.Load<Sprite>("Icons/triangle-up");
			Debug.Log("descending: " + isOn);
		}
		else
		{
			isOn = true;
            buttonImage.sprite = Resources.Load<Sprite>("Icons/triangle-down");
			Debug.Log("descending: " + isOn);
		}
	}
}
