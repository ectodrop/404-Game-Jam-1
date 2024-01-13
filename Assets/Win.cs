using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneTrigger : MonoBehaviour
{
    public GameObject winPanel;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is the one touching the plane
        if (other.CompareTag("Player")) // Make sure your player GameObject has the tag "Player"
        {
            Debug.Log("Touched!");
            winPanel.SetActive(true); // Show the win panel
        }
    }
}