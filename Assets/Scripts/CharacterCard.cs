using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCard : MonoBehaviour
{
    // 캐릭터 카드 상의 각 UI 요소들 참조
    public TMP_Text nameText;
    public Image portraitImage;
    public Image rarityImage;
    public Image jobIconImage;
    public RectTransform starImageTransform;
	public TMP_Text levelText;
    public TMP_Text powerText;

    // UI에 표시될 별 갯수 조절을 위한 별 1개의 길이
    private int widthOfOneStar = 34;

    // Character 객체의 필드들을 캐릭터 카드 UI에 뿌려주는 기능
    // CharacterListController에서 호출
    public void Bind(Character character)
    {
        nameText.text = character.Name;
        levelText.text = character.Level.ToString();
        portraitImage.sprite = Resources.Load<Sprite>(character.PortraitUrl);
        jobIconImage.sprite = Resources.Load<Sprite>(character.Job.IconUrl);
        starImageTransform.sizeDelta = 
            new Vector2(widthOfOneStar * character.NumOfStar, starImageTransform.sizeDelta.y);

        switch (character.Rarity)
        {
            case 1:
                rarityImage.color = Color.blue;
                break;
            case 2:
                rarityImage.color = Color.green;
                break;
            case 3:
                rarityImage.color = Color.yellow;
                break;
        }

        int power = Utils.CalculatePower(character.MaxHp, character.Damage, character.Armor);
        powerText.text = power.ToString();
    }
}
