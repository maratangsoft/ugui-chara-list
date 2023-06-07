using System;
using UnityEngine;

[Serializable]
public class Role
{
	[SerializeField] int roleId;
	[SerializeField] string roleName;

	public int RoleId { get => roleId; set => roleId = value; }
	public string RoleName { get => roleName; set => roleName = value; }
}
