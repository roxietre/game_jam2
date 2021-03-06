using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberTemplates : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject[] bottomChambers;
	public GameObject[] topChambers;
	public GameObject[] leftChambers;
	public GameObject[] rightChambers;

	public List<GameObject> chambers;
	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;

	void Update(){
		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < chambers.Count; i++) {
				if(i == chambers.Count-1) {
				Destroy (chambers[i].gameObject);
				Instantiate(boss, chambers[i].transform.position, Quaternion.identity);
				spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
