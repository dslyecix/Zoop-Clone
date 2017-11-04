using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour {

    Transform sectionTarget;
    Transform centerTarget;

	int numberOfTiers;

    public float length;

	float tierDist;


	Node[] nodes;

    void Start ()
    {
        nodes = new Node[numberOfTiers];
        tierDist = length / numberOfTiers;

        CreateNodes();
    }

    void Update () 
	{
		
        UpdatePositionAndRotation();
        UpdateNodePositionAndRotation();
        
        DrawDebugLines();
    }

    private void UpdateNodePositionAndRotation()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i].transform.position = this.transform.position + i * tierDist * -transform.forward;
            nodes[i].transform.rotation = this.transform.rotation;
        }
        
    
    }

    private void UpdatePositionAndRotation()
    {
        if (sectionTarget) {
            transform.position = sectionTarget.transform.position;
            transform.rotation = Quaternion.LookRotation(centerTarget.position - this.transform.position, Vector3.up);
        } else {
            Debug.Log("Section " + name + " has no target to follow!");
        }
    }

    private void CreateNodes()
    {
        for (int i = 0; i < numberOfTiers; i++)
        {
            GameObject GO = new GameObject("Node " + i);
            GO.transform.position = this.transform.position + i * tierDist * -transform.forward;
            GO.transform.parent = this.transform;
    		nodes[i] = GO.AddComponent<Node>();
        }
    }

    private void DrawDebugLines()
    {
        Debug.DrawLine(this.transform.position, nodes[0].transform.position, Color.blue);

        for (int i = 1; i < numberOfTiers; i++)
        {
            Debug.DrawLine(nodes[i - 1].transform.position, nodes[i].transform.position, new Color((1 - 0.1f * i), (0.2f * i), 1 - (0.2f * i), 1));
        }
    }

    public Node ReturnNextEmptyNode () {
		for (int i = 0; i < numberOfTiers; i++)
		{
			if (nodes[i].isEmpty) {
				// nodes[i].isEmpty = false;
				return nodes[i];
			}
		}
		return null;
	}

    public void SetSectionTarget (Transform target) {
        sectionTarget = target;
    }

    public void SetSectionLength (float _length) {
        length = _length;
    }

    public void SetCenterTarget (Transform parent) {
        centerTarget = parent;
    }

    public void SetTiers (int tierNumber) {
        numberOfTiers = tierNumber;
    }

}
