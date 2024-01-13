using UnityEngine;
using System; 
using System.Collections.Generic; 

public class PlayerMovement : MonoBehaviour
{
    private List<GameObject> boxes;
    public GameObject capsule;
    public GameObject boxFab;
    public float moveSpeed = 5f; // Adjust this value to set the movement speed.

    void Start()
    {
        boxes = new List<GameObject>();
        // Freeze rotation on the X and Z axes.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
        GameObject child = Instantiate(boxFab, capsule.transform);
        child.transform.position = new Vector3(0, 1, 0);
        boxes.Add(child);
        child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        for (int i = 1; i < 10; i++)
        {
            child = Instantiate(boxFab, capsule.transform);
            HingeJoint joint = child.GetComponent<HingeJoint>();
            boxes[boxes.Count-1].GetComponent<HingeJoint>().connectedBody = child.GetComponent<Rigidbody>();
            boxes.Add(child);
            child.transform.position = new Vector3(0, i+1, 0);
        }
        boxes[boxes.Count-1].GetComponent<HingeJoint>().connectedBody = boxes[boxes.Count-2].GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input values for horizontal and vertical axes.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction.
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        
        foreach (GameObject go in boxes)
        {
            go.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100f, 0));
        }
        
        // Move the Rigidbody.
        transform.Translate(movement);
    }

    void OnCollisionEnter()
    {
        
    }
}
