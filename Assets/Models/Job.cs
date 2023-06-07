using System;
using UnityEngine;

[Serializable]
public class Job
{
	[SerializeField] int jobId;
	[SerializeField] string jobName;
	[SerializeField] string iconUrl;

	public Job(){}

	public Job(int jobId, string jobName, string iconUrl)
	{
		JobId = jobId;
		JobName = jobName;
		IconUrl = iconUrl;
	}

	public int JobId { get => jobId; set => jobId = value; }
	public string JobName { get => jobName; set => jobName = value; }
	public string IconUrl { get => iconUrl; set => iconUrl = value; }
}
