using UnityEngine;
using UnityEngine.UI;

class SortToggle : MonoBehaviour
{
	public Image buttonImage;
	public bool descending;

	public void OnClick()
	{
		if (descending)
		{
			descending = false;
			buttonImage.sprite = Resources.Load<Sprite>("Icons/triangle-up");
			Debug.Log("descending: " + descending);
		}
		else
		{
			descending = true;
            buttonImage.sprite = Resources.Load<Sprite>("Icons/triangle-down");
			Debug.Log("descending: " + descending);
		}
	}
}
