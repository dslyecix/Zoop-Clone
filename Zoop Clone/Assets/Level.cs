using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	[Range(1,8)]
	public int numberOfSections;

    public List<Section> sections = new List<Section>();

    float radius = 5f;
	float sectionAngleBetween;

    void Awake () {
		sectionAngleBetween = 360 / numberOfSections;
		CreateSections();
	}

	void Update() {
		for (int i = 0; i < sections.Count; i++)
		{
			Debug.DrawLine (this.transform.position,sections[i].transform.position,Color.red);
		}
	}

    private void CreateSections()
    {
		for (int i = 0; i < numberOfSections; i++)
		{
			GameObject GO = new GameObject ("Section " + i);
			float angle = i * sectionAngleBetween;
			GO.transform.position = this.transform.position + radius * new Vector3(Mathf.Cos(i * sectionAngleBetween * Mathf.Deg2Rad), 0, Mathf.Sin(i * sectionAngleBetween * Mathf.Deg2Rad));
			GO.transform.parent = this.transform;
			sections.Add(GO.AddComponent<Section>());
		}		
    }
}
