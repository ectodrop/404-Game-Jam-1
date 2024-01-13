using UnityEngine;

public class Player_Collision_Knock_Away : MonoBehaviour
{
    // Adjust this force value to control how much the player is pushed
    public float impactForce = 10f;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the "Vehicle" tag
        if (collision.gameObject.CompareTag("Vehicle"))
        {
            // Calculate the direction from the player to the bus
            Vector3 impactDirection = (transform.position - collision.transform.position).normalized;

            // Apply a force to the player in the calculated direction
            GetComponent<Rigidbody>().AddForce(impactDirection * impactForce, ForceMode.Impulse);
            

            Debug.Log("Player hit by a vehicle!");
        }
    }
}
