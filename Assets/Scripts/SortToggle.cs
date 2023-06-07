using UnityEngine;
using UnityEngine.UI;

class SortToggle : MonoBehaviour
{
	public bool descending;

	public void OnClick()
	{
		if (descending)
		{
			descending = false;
			GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/triangle-up");
			Debug.Log("descending: " + descending);
		}
		else
		{
			descending = true;
			GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/triangle-down");
			Debug.Log("descending: " + descending);
		}
	}
}
