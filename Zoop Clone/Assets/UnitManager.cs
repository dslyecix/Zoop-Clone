using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitManager : MonoBehaviour {

	[SerializeField] List<Unit> units;
	public Level level;

	Material defaultMaterial;

	void Start () {
		units = new List<Unit>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)){
			CreateNewUnit ();
		}
	}

	void CreateNewUnit () {

		ColorType newColorType = GetRandomColorType();
		int newSectionIndex = GetRandomSectionIndex();
		Section newSection = level.sections[newSectionIndex];

		GameObject newUnit = new GameObject("Unit " + units.Count);
		
		MeshFilter meshFilter = newUnit.AddComponent<MeshFilter>();
		meshFilter.mesh = GetMeshFromPrimitive(PrimitiveType.Sphere);
		MeshRenderer meshRenderer = newUnit.AddComponent<MeshRenderer>();
		meshRenderer.sharedMaterial = defaultMaterial;

		Unit tempUnit = newUnit.AddComponent<Unit>();
		tempUnit.SetSection(newSection);
		tempUnit.GetNewNode();
		units.Add(tempUnit);
		
		
		//newUnit.transform.position = level.sections[newSectionIndex].ReturnNextEmptyNode();
		
	}

	int GetRandomSectionIndex () {
		return UnityEngine.Random.Range(0,level.sections.Length);
	}

	ColorType GetRandomColorType () {
		int length = Enum.GetNames(typeof(ColorType)).Length;
		return (ColorType)UnityEngine.Random.Range(0,length);
	}

	private Mesh GetMeshFromPrimitive (PrimitiveType type){
		GameObject GO = GameObject.CreatePrimitive(type);
		Mesh tempMesh;
		defaultMaterial = GO.GetComponent<MeshRenderer>().sharedMaterial;
		tempMesh = GO.GetComponent<MeshFilter>().mesh;
		Destroy(GO);
		return tempMesh;
	}


}
