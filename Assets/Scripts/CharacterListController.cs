using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterListController : MonoBehaviour
{
    public Button btnFilterByFavorited;
    public Button btnFilterByOwned;
	public GameObject characterCard;
	public GameObject gridLayout;

	private HttpClient client = new HttpClient();
	private List<Character> characters;

	bool sortedByLevelInDesc = true;
	bool sortedByStarInDesc = false;
    bool sortedByPowerInDesc = false;
    bool sortedByGetDateInDesc = false;

	bool filteredByFavorited = false;
	bool filteredByOwned = true;

	private void Start()
	{
        // 서버로부터 캐릭터 데이터 불러오기 (현재는 더미데이터)
        characters = client.FetchCharacters();
        // 소유중인 캐릭터만 출력하도록 필터링
        List<Character> filteredList = characters.Where(item => item.IsOwned).ToList();
        // 필터링한 리스트 UI에 뿌리기
        Populate(filteredList);
	}

	public void OnBtnBackClick()
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
	public void OnTglFilterByStarChange(int NumberOfStars)
	{
		List<Character> filteredList = characters.Where(item => item.IsFavorited).ToList();
		Populate(filteredList);
	}
	public void OnTglFilterByJobChange(int jobId)
	{
		List<Character> filteredList = characters.Where(item => item.IsFavorited).ToList();
		Populate(filteredList);
	}

    // UI에 리스트 뿌리는 기능
    private void Populate(List<Character> list)
	{
        // 화면 갱신시 리스트가 계속 쌓이지 않도록 기존 객체들 없애기
        foreach (Transform child in gridLayout.transform)
		{
			Destroy(child.gameObject);
		}

        // GridLayoutGroup 안에 캐릭터 카드 프리팹 넣고 데이터 바인딩
        foreach (Character item in list)
		{
			GameObject go = Instantiate(characterCard, gridLayout.transform);
			go.GetComponent<CharacterCard>().Bind(item);
		}
	}
}
