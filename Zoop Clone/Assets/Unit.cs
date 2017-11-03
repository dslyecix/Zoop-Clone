using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Section section;
	public ColorType type;

	public int tier;



    void Start () {
		
		MoveToNode(section.ReturnEmptyNode());

	}

	void MoveToNode (Node node) {
		transform.position = node.transform.position;
		node.SetCurrentUnit(this);
	}



}
