using System;
using UnityEngine;

[Serializable]
public class Character
{
	// immutable values
	// personal information
	private int characterId;
	private string name;
	private string englishName;
	private int rarity;
	private string illustUrl;
	private string portraitUrl;

	// job & roles
	private Job job;
	private Role mainRole;
	private Role subRole;

	// skills
	private Skill passiveSkill;
	private Skill activeSkill;
	private Skill ultimateSkill;

	// mutable values
	private int numOfStar;
	private long getDate;
	private int level;
	private int maxHp;
	private int damage;
	private int armor;
	private int intimacy;
	private bool isOwned;
	private bool isFavorited;

	public Character() { }
	public Character(
		int characterId,
		string name,
		int rarity,
		string portraitUrl,
		Job job,
		int numOfStar,
		long getDate,
		int level,
		int maxHp,
		int damage,
		int armor,
		bool isOwned,
		bool isFavorited
		) 
	{ 
		CharacterId = characterId;
		Name = name;
		Rarity = rarity;
		PortraitUrl = portraitUrl;
		Job = job;
		NumOfStar = numOfStar;
		GetDate = getDate;
		Level = level;
		MaxHp = maxHp;
		Damage = damage;
		Armor = armor;
		IsOwned = isOwned;
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
	public int NumOfStar { get => numOfStar; set => numOfStar = value; }
	public long GetDate { get => getDate; set => getDate = value; }
	public int Level { get => level; set => level = value; }
	public int MaxHp { get => maxHp; set => maxHp = value; }
	public int Damage { get => damage; set => damage = value; }
	public int Armor { get => armor; set => armor = value; }
	public int Intimacy { get => intimacy; set => intimacy = value; }
	public bool IsOwned { get => isOwned; set => isOwned = value; }
	public bool IsFavorited { get => isFavorited; set => isFavorited = value; }
}
