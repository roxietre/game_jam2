using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddChamber : MonoBehaviour
{
	private ChamberTemplates templates;

	void Start(){

		templates = GameObject.FindGameObjectWithTag("Chambers").GetComponent<ChamberTemplates>();
		templates.chambers.Add(this.gameObject);
	}
}
