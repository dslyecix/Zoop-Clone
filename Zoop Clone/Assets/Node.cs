using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

	public bool isEmpty = true;

	Unit currentUnit;

	public void SetCurrentUnit (Unit unit) {
		currentUnit = unit;

	}

}
