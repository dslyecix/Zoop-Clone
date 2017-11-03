using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	[Range(1,8)]
	public int numberOfSections;

	GameObject[] sectionTargets;
	public Section[] sections;
    
	[Range(1,10)]
	public int numberOfTiers;

    float radius = 5f;
	float sectionAngleBetween;

	public float sectionLength;

    void Start () {
		sectionTargets = new GameObject[numberOfSections];
		sections = new Section[numberOfSections];

		sectionAngleBetween = 360 / numberOfSections;

		CreateSectionTargets();
		CreateSections();
	}


    void Update()
    {
        DrawDebugLines();
    }

	private void DrawDebugLines()
	{
		for (int i = 0; i < numberOfSections; i++)
		{
			Debug.DrawLine(this.transform.position, sectionTargets[i].transform.position, Color.red);
		}
	}

    private void CreateSectionTargets()
    {
        for (int i = 0; i < numberOfSections; i++)
		{
			sectionTargets[i] = new GameObject ("Section target " + i);
			float angle = i * sectionAngleBetween;

			sectionTargets[i].transform.position = this.transform.position + radius * new Vector3(Mathf.Cos(i * sectionAngleBetween * Mathf.Deg2Rad), Mathf.Sin(i * sectionAngleBetween * Mathf.Deg2Rad), 0);
			sectionTargets[i].transform.rotation = Quaternion.LookRotation(this.transform.position - sectionTargets[i].transform.position, Vector3.up);
			sectionTargets[i].transform.parent = this.transform;
		}
    }

    private void CreateSections()
    {
		for (int i = 0; i < numberOfSections; i++)
		{
			GameObject GO = new GameObject ("Section " + i);
			
			sections[i] = GO.AddComponent<Section>();
			sections[i].SetSectionTarget(sectionTargets[i].transform);
			sections[i].SetSectionLength(sectionLength);
			sections[i].SetCenterTarget(this.transform);
			sections[i].SetTiers(numberOfTiers);

		}				
    }
}
