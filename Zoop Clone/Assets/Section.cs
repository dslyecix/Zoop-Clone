using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour {

	int tiers = 6;
	float length = 18f;
	float tierDist;

	Vector3 parentDirection;

	List<Spot> spots = new List<Spot>();

    void Awake ()
    {
        tierDist = length / tiers;
        parentDirection = (transform.parent.transform.position - transform.position).normalized;
        CreateSpots();
    }

    void Update () 
	{
		for (int i = 0; i < spots.Count; i++)
        {
            UpdatePositions(i);
            Debug.DrawLine(this.transform.position, spots[i].transform.position, Color.blue);
        }
    }

    private void CreateSpots()
    {
        for (int i = 0; i < tiers; i++)
        {
            GameObject GO = new GameObject("Spot " + i);
            GO.transform.position = this.transform.position + i * tierDist * -parentDirection;
            GO.transform.parent = this.transform;
			spots.Add(GO.AddComponent<Spot>());
        }
    }
   
    private void UpdatePositions(int i)
    {
        parentDirection = (transform.parent.transform.position - transform.position).normalized;
        spots[i].transform.position = this.transform.position + i * tierDist * -parentDirection;
    }

	public Vector3 ReturnEmptySpot () {
		for (int i = 0; i < tiers; i++)
		{
			if (spots[i].isEmpty) {
				spots[i].isEmpty = false;
				return spots[i].transform.position;
			}
		}
		return Vector3.zero;
	}

}
