using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterListController : MonoBehaviour
{
	public GameObject characterCard;
	public GameObject gridLayout;

	private HttpClient client = new HttpClient();
	private List<Character> originalList;
	private List<Character> sortedList;
	private List<Character> filteredList;

	public SortToggle sortByLevelToggle;
	public SortToggle sortByStarToggle;
	public SortToggle sortByPowerToggle;
	public SortToggle sortByGetDateToggle;
	public Toggle filterByFavoritedToggle;
	public Toggle filterByOwnedToggle;

	private void Start()
	{
		originalList = client.FetchCharacters();
		sortedList = originalList;
		filteredList = originalList.Where(item => item.IsOwned).ToList();
		Populate(filteredList);
	}

	public void OnToggleChange()
	{
		IEnumerable<Character> query = sortedList;

		if (sortByLevelToggle.isOn)
			query = query.OrderByDescending(item => item.Level);
		else
			query = query.OrderBy(item => item.Level);

		if (sortByStarToggle.isOn)
			query = query.OrderByDescending(item => item.NumOfStar);
		else
			query = query.OrderBy(item => item.NumOfStar);

		if (sortByPowerToggle.isOn)
			query = query.OrderByDescending(item => 
				Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
			);
		else
			query = query.OrderBy(item =>
				Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
			);

		if (sortByGetDateToggle.isOn)
			query = query.OrderByDescending(item => item.GetDate);
		else
			query = query.OrderBy(item => item.GetDate);

		sortedList = query.ToList();

		IEnumerable<Character> filteringList = sortedList;

		if (filterByFavoritedToggle.isOn)
			filteringList = filteringList.Where(item => item.IsFavorited);

		if (filterByOwnedToggle.isOn)
			filteringList = filteringList.Where(item => item.IsOwned);

		Populate(filteringList.ToList());
	}

	/*public void OnBtnBackClick()
    {
        // has no feature
    }
    public void OnBtnHomeClick()
    {
		// has no feature
	}
	public void OnBtnNavigationClick()
    {
		// has no feature
	}

	public void OnToggleValueChange()
	{

	}
    public void OnBtnSortClick(int sortMode)
    {
		List<Character> sortedList = null;
		switch (sortMode)
        {
            case (int)SortMode.LEVEL:
				if (sortedByLevelInDesc)
				{
					sortedList = characters.OrderBy(item => item.Level).ToList();
					sortedByLevelInDesc = false;
				}
				else
				{
					sortedList = characters.OrderByDescending(item => item.Level).ToList();
					sortedByLevelInDesc = true;
				}
                break;

			case (int)SortMode.STAR:
				if (sortedByStarInDesc)
				{
					sortedList = characters.OrderBy(item => item.NumOfStar).ToList();
					sortedByStarInDesc = false;
				}
				else
				{
					sortedList = characters.OrderByDescending(item => item.NumOfStar).ToList();
					sortedByStarInDesc = true;
				}
				break;

			case (int)SortMode.POWER:
				if (sortedByPowerInDesc)
				{
					sortedList = characters.OrderBy(item => 
						Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
					).ToList();
					sortedByPowerInDesc = false;
				}
				else
				{
					sortedList = characters.OrderByDescending(item =>
						Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
					).ToList();
					sortedByPowerInDesc = true;
				}
				break;

			case (int)SortMode.GET_DATE:
				if (sortedByGetDateInDesc)
				{
					sortedList = characters.OrderBy(item => item.GetDate).ToList();
					sortedByGetDateInDesc = false;
				}
				else
				{
					sortedList = characters.OrderByDescending(item => item.GetDate).ToList();
					sortedByGetDateInDesc = true;
				}
				break;
		}
		Debug.Log("sortedByLevelInDesc: " + sortedByLevelInDesc);
		Debug.Log("sortedByStarInDesc: " + sortedByStarInDesc);
		Debug.Log("sortedByPowerInDesc: " + sortedByPowerInDesc);
		Debug.Log("sortedByGetDateInDesc: " + sortedByGetDateInDesc);

		Populate(sortedList);
    }
	public void OnTglFilterByFavoritedChange(bool isChecked)
	{
		


		List<Character> filteredList = null;
		if (filteredByFavorited)
		{
			filteredList = characters;
			filteredByFavorited = false;
		}
		else
		{
			filteredList = characters.Where(item => item.IsFavorited).ToList();
			filteredByFavorited = true;
		}
			
		Populate(filteredList);
	}
	public void OnTglFilterByOwnedChange(bool isChecked)
	{
		List<Character> filteredList = null;
		if (filteredByOwned)
		{

			filteredList = characters;
			filteredByOwned = false;
		}
		else
		{
			filteredList = characters.Where(item => item.IsOwned).ToList();
			filteredByOwned = true;
		}

		Populate(filteredList);
	}
	public void OnBtnOpenFilterListClick()
	{

	}
	public void OnTglFilterByStarChange(int NumOfStar)
	{
		List<Character> filteredList = characters.Where(item => item.IsFavorited).ToList();
		Populate(filteredList);
	}
	public void OnTglFilterByJobChange(int jobId)
	{
		List<Character> filteredList = characters.Where(item => item.IsFavorited).ToList();
		Populate(filteredList);
	}*/

	private void Populate(List<Character> list)
	{
		foreach (Transform child in gridLayout.transform)
		{
			Destroy(child.gameObject);
		}

		foreach (Character item in list)
		{
			GameObject go = Instantiate(characterCard, gridLayout.transform);
			go.GetComponent<CharacterCard>().Bind(item);
		}
	}
}
