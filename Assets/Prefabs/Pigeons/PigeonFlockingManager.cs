using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFlockingManager : MonoBehaviour
{
    
    public static PigeonFlockingManager Singleton;
    public GameObject pigeonPrefab;

    public int numPigeons = 5;

    public GameObject[] allPigeons;

    public Vector3 flyBounds = new Vector3(3,3,3);

    [Header("Pigeon Flight Settings")]
    public Vector3 goalPos = Vector3.zero;
    [Range(0f, 5f)]
    public float minSpeed;
    [Range(0f, 5f)]
    public float maxSpeed;
    [Range(1f, 10f)]
    public float neighborDistance;
    [Range(1f, 5f)]
    public float rotationSpeed;
    [Range(1f, 5f)]
    public float avoidanceDistance;

    // Start is called before the first frame update
    void Start()
    {
        allPigeons = new GameObject[numPigeons];
        
        for (int i = 0; i < numPigeons; i++) {
            Vector3 initialPos = this.transform.position + new Vector3(Random.Range(-flyBounds.x, flyBounds.x), Random.Range(-flyBounds.y, flyBounds.y), Random.Range(-flyBounds.z, flyBounds.z));

            allPigeons[i] = Instantiate(pigeonPrefab, initialPos, Quaternion.identity);

            allPigeons[i].GetComponent<PigeonFlock>().flockManager = this;
        }

        Singleton = this;

        goalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Random.Range(0, 100) < 10) {
        //     goalPos = this.transform.position + new Vector3(Random.Range(-flyBounds.x, flyBounds.x), Random.Range(-flyBounds.y, flyBounds.y), Random.Range(-flyBounds.z, flyBounds.z));
        // }
        transform.position += new Vector3(0f, 0f, 1f * Time.deltaTime);
    }
}
