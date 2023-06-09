using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterListController : MonoBehaviour
{
	public GameObject characterCard;
	public GameObject gridLayout;

	private HttpClient client = new HttpClient();
	private List<Character> sortedList;

    public Toggle sortByLevelToggle;
    public Toggle sortByStarToggle;
    public Toggle sortByPowerToggle;
    public Toggle sortByGetDateToggle;
    public Toggle filterByFavoritedToggle;
    public Toggle filterByOwnedToggle;

    public GameObject filterPopup;

    void Start()
	{
        sortByLevelToggle.onValueChanged.AddListener(SortByLevel);
        sortByStarToggle.onValueChanged.AddListener(SortByStar);
        sortByPowerToggle.onValueChanged.AddListener(SortByPower);
        sortByGetDateToggle.onValueChanged.AddListener(SortByGetDate);
        filterByFavoritedToggle.onValueChanged.AddListener(OnFilterChanged);
        filterByOwnedToggle.onValueChanged.AddListener(OnFilterChanged);

		List<Character> characterList = client.FetchCharacters();

        sortedList = InitialSort(characterList);

        List<Character> filteredList = ApplyFilter(sortedList);
        Populate(filteredList);
	}

    public void ShowFilterPopup()
    {
        filterPopup.SetActive(true);
    }

    public void OnFilterChanged(bool isOn)
    {
        List<Character> filteredList = ApplyFilter(sortedList);
        Populate(filteredList);
    }

    private List<Character> InitialSort(List<Character> characterList)
    {
        IEnumerable<Character> query = characterList;
        query = query.OrderByDescending(item => item.GetDate)
                     .OrderByDescending(item =>
                         Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
                     ).OrderByDescending(item => item.NumOfStar)
                     .OrderByDescending(item => item.Level);

        return query.ToList();
    }

    private void SortByLevel(bool inDescending)
    {
        Debug.Log("isOn: " + inDescending);
        if (inDescending)
        {
            sortedList =
                sortedList.OrderByDescending(item => item.Level).ToList();
        }
        else
        {
            sortedList =
                sortedList.OrderBy(item => item.Level).ToList();
        }
        List<Character> filteredList = ApplyFilter(sortedList);
        Populate(filteredList);
    }

    private void SortByStar(bool inDescending)
    {
        Debug.Log("isOn: " + inDescending);
        if (inDescending)
        {
            sortedList =
                sortedList.OrderByDescending(item => item.NumOfStar).ToList();
        }
        else
        {
            sortedList =
                sortedList.OrderBy(item => item.NumOfStar).ToList();
        }
        List<Character> filteredList = ApplyFilter(sortedList);
        Populate(filteredList);
    }

    private void SortByPower(bool inDescending)
    {
        Debug.Log("isOn: " + inDescending);
        if (inDescending)
        {
            sortedList = sortedList.OrderByDescending(item =>
                Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
            ).ToList();
        }
        else
        {
            sortedList = sortedList.OrderBy(item =>
                Utils.CalculatePower(item.MaxHp, item.Damage, item.Armor)
            ).ToList();
        }
        List<Character> filteredList = ApplyFilter(sortedList);
        Populate(filteredList);
    }

    private void SortByGetDate(bool inDescending)
    {
        Debug.Log("isOn: " + inDescending);
        if (inDescending)
        {
            sortedList =
                sortedList.OrderByDescending(item => item.GetDate).ToList();
        }
        else
        {
            sortedList =
                sortedList.OrderBy(item => item.GetDate).ToList();
        }
        List<Character> filteredList = ApplyFilter(sortedList);
        Populate(filteredList);
    }

    public List<Character> ApplyFilter(List<Character> sortedList)
    {
        IEnumerable<Character> query = sortedList;

        if (filterByFavoritedToggle.isOn)
            query = query.Where(item => item.IsFavorited);

        if (filterByOwnedToggle.isOn)
            query = query.Where(item => item.IsOwned);

        bool[] filtersFromPopup =
            filterPopup.GetComponent<FilterPopupController>().ToggleValues;

        if (!filtersFromPopup[(int)PopupFilters.STAR_3])
            query = query.Except(query.Where(item => item.NumOfStar == 3));

        if (!filtersFromPopup[(int)PopupFilters.STAR_4])
            query = query.Except(query.Where(item => item.NumOfStar == 4));

        if (!filtersFromPopup[(int)PopupFilters.STAR_5])
            query = query.Except(query.Where(item => item.NumOfStar == 5));

        if (!filtersFromPopup[(int)PopupFilters.JOB_TANKER])
            query = query.Except(query.Where(item => item.Job.JobId == 0));

        if (!filtersFromPopup[(int)PopupFilters.JOB_DEALER])
            query = query.Except(query.Where(item => item.Job.JobId == 1));

        if (!filtersFromPopup[(int)PopupFilters.JOB_HEALER])
            query = query.Except(query.Where(item => item.Job.JobId == 2));

        return query.ToList();
    }

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
