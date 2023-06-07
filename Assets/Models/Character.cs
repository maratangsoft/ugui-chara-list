using System;
using UnityEngine;

[Serializable]
public class Character
{
	// immutable values
	// personal information
	[SerializeField] private int characterId;
	[SerializeField] private string name;
	[SerializeField] private string englishName;
	[SerializeField] private int rarity;
	[SerializeField] private string illustUrl;
	[SerializeField] private string portraitUrl;

	// job & roles
	[SerializeField] private Job job;
	[SerializeField] private Role mainRole;
	[SerializeField] private Role subRole;

	// skills
	[SerializeField] private Skill passiveSkill;
	[SerializeField] private Skill activeSkill;
	[SerializeField] private Skill ultimateSkill;

	// mutable values
	[SerializeField] private int star;
	[SerializeField] private int getDate;
	[SerializeField] private int level;
	[SerializeField] private int maxHp;
	[SerializeField] private int damage;
	[SerializeField] private int armor;
	[SerializeField] private int intimacy;
	[SerializeField] private bool isFavorited;

	public Character() { }
	public Character(
		int characterId, 
		string name, 
		int rarity, 
		string portraitUrl, 
		Job job, 
		int star, 
		int level, 
		int maxHp,
		int damage,
		int armor,
		bool isFavorited
		) 
	{ 
		CharacterId = characterId;
		Name = name;
		Rarity = rarity;
		PortraitUrl = portraitUrl;
		Job = job;
		Star = star;
		Level = level;
		MaxHp = maxHp;
		Damage = damage;
		Armor = armor;
		IsFavorited = isFavorited;
	}

	public int CharacterId { get => characterId; set => characterId = value; }
	public string Name { get => name; set => name = value; }
	public string EnglishName { get => englishName; set => englishName = value; }
	public int Rarity { get => rarity; set => rarity = value; }
	public string IllustUrl { get => illustUrl; set => illustUrl = value; }
	public string PortraitUrl { get => portraitUrl; set => portraitUrl = value; }
	public Job Job { get => job; set => job = value; }
	public Role MainRole { get => mainRole; set => mainRole = value; }
	public Role SubRole { get => subRole; set => subRole = value; }
	public Skill PassiveSkill { get => passiveSkill; set => passiveSkill = value; }
	public Skill ActiveSkill { get => activeSkill; set => activeSkill = value; }
	public Skill UltimateSkill { get => ultimateSkill; set => ultimateSkill = value; }
	public int Star { get => star; set => star = value; }
	public int GetDate { get => getDate; set => getDate = value; }
	public int Level { get => level; set => level = value; }
	public int MaxHp { get => maxHp; set => maxHp = value; }
	public int Damage { get => damage; set => damage = value; }
	public int Armor { get => armor; set => armor = value; }
	public int Intimacy { get => intimacy; set => intimacy = value; }
	public bool IsFavorited { get => isFavorited; set => isFavorited = value; }
}
