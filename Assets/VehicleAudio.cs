using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAudio : MonoBehaviour
{
    public float distance;
    private bool hasNotPlayed = true;
    void Update() {

        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];

        if (hasNotPlayed && ((player.transform.position - transform.position).magnitude <= distance)) {
            GetComponent<AudioSource>().Play();
        }

    }
}
