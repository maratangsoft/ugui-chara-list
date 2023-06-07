using System;
using UnityEngine;

[Serializable]
public class Skill
{
	[SerializeField] int skillId;
	[SerializeField] string skillName;
	[SerializeField] string iconUrl;

	public int SkillId { get => skillId; set => skillId = value; }
	public string SkillName { get => skillName; set => skillName = value; }
	public string IconUrl { get => iconUrl; set => iconUrl = value; }
}
