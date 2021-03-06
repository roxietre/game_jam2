using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private ChamberTemplates chambers;
	public bool spawned = false;
	private int rand;
	public float waitTime = 4f;
	

	void Start(){
		Destroy(gameObject, waitTime);
		//templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		chambers = GameObject.FindGameObjectWithTag("Chambers").GetComponent<ChamberTemplates>();
		Invoke("Spawn", 0.1f);
	}


	void Spawn(){
		if(spawned == false){
			if(openingDirection == 1){
				// Need to spawn a room with a BOTTOM door.
				rand = Random.Range(0, chambers.bottomChambers.Length);
				//Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
				Instantiate(chambers.bottomChambers[rand], transform.position, chambers.bottomChambers[rand].transform.rotation);
			} else if(openingDirection == 2){
				// Need to spawn a room with a TOP door.
				rand = Random.Range(0, chambers.topChambers.Length);
				//Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
				Instantiate(chambers.topChambers[rand], transform.position, chambers.topChambers[rand].transform.rotation);
			} else if(openingDirection == 3){
				// Need to spawn a room with a LEFT door.
				rand = Random.Range(0, chambers.leftChambers.Length);
				//Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
				Instantiate(chambers.leftChambers[rand], transform.position, chambers.leftChambers[rand].transform.rotation);
			} else if(openingDirection == 4){
				// Need to spawn a room with a RIGHT door.
				rand = Random.Range(0, chambers.rightChambers.Length);
				//Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
				Instantiate(chambers.rightChambers[rand], transform.position, chambers.rightChambers[rand].transform.rotation);
			}
			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("SpawnPoint")){
			if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				//Destroy(gameObject);
			}
			spawned = true;
		}
	}
}
