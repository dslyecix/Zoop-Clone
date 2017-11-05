using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Section section;

	Node currentNode;
	
	public ColorType type;

	public int tier;



    void Start () {
		//Debug.Log("Your section is " + section.name);
		if (currentNode) MoveToNode(currentNode);

	}

    void Update () {
		if (currentNode) MoveToNode(currentNode);
	}

    public void GetNewNode()
    {
		if (currentNode) currentNode.ClearCurrentUnit();
        currentNode = section.ReturnNextEmptyNode();
		if (currentNode) currentNode.SetCurrentUnit(this);
    }

	public void MoveToNode (Node node) {
		transform.position = node.transform.position;
	}

	public void SetSection (Section _section) {
		section = _section;
	}

	public void UpdateType (ColorType _type) {
		type = _type;
	}

	

}
