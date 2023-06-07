using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterItem : MonoBehaviour
{
    public TMP_Text nameText;
    public Image portraitImage;
    public Image rarityImage;
    public Image jobIconImage;
    public RectTransform starImageTransform;
	public TMP_Text levelText;
    public TMP_Text powerText;

    public void Set(Character character)
    {
        nameText.text = character.Name;
        levelText.text = character.Level.ToString();
        portraitImage.sprite = Resources.Load<Sprite>(character.PortraitUrl);
        jobIconImage.sprite = Resources.Load<Sprite>(character.Job.IconUrl);
        starImageTransform.sizeDelta = new Vector2(34 * character.Star, starImageTransform.sizeDelta.y);

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
