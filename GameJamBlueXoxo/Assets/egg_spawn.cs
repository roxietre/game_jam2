using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg_spawn : MonoBehaviour
{
    // create a randome number of object_egg to spawn in the map

    public GameObject object_egg;
    private int number_of_egg;

    public void Start()
    {
        number_of_egg = Random.Range(0, 3);
        //debug print map name and number of egg c
        Debug.Log("map name: " + Application.loadedLevelName);

        for (int i = 0; i < number_of_egg; i++)
        {
            // create a random position in the map
            Vector3 position = new Vector3(Random.Range(transform.position.x - 5 , transform.position.x +5 ), Random.Range(transform.position.y -5 , transform.position.y +5), 0);
            // create a new object_egg
            Instantiate(object_egg, position, Quaternion.identity);
        }
    }
}
