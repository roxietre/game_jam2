using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAgro : MonoBehaviour
{
    public SpiderEggBehavior spiderEgg;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            spiderEgg.inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            spiderEgg.inRange = false;
        }
    }
}
