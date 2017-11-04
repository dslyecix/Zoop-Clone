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

		GetNewNode();
		//Debug.Log("Your section is " + section.name);
		MoveToNode(currentNode);

	}

    void Update () {
		if(currentNode) MoveToNode(currentNode);
	}

    private void GetNewNode()
    {
		if(currentNode) currentNode.ClearCurrentUnit();
        currentNode = section.ReturnNextEmptyNode();
		currentNode.SetCurrentUnit(this);
    }

	public void MoveToNode (Node node) {
		transform.position = node.transform.position;
	}

	public void SetSection (Section _section) {
		section = _section;
	}

}
