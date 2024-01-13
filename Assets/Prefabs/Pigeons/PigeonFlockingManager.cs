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
    public float flyAwaySpeed;
    public Vector3 flyAwayDirection;

    // Start is called before the first frame update
    void Start()
    {
        allPigeons = new GameObject[numPigeons];
        
        for (int i = 0; i < numPigeons; i++) {
            Vector3 initialPos = this.transform.position + new Vector3(Random.Range(-flyBounds.x, flyBounds.x), 0, Random.Range(-flyBounds.z, flyBounds.z));

            allPigeons[i] = Instantiate(pigeonPrefab, initialPos, Quaternion.identity);

            allPigeons[i].GetComponent<PigeonFlock>().flockManager = this;
        }

        Singleton = this;

        goalPos = this.transform.position;
    }

    void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            
            StartCoroutine(FlyAway());
            GetComponent<AudioSource>().Play();

            GetComponent<BoxCollider>().enabled = false;

            foreach (GameObject pigeon in allPigeons) {
                pigeon.transform.GetChild(0).gameObject.SetActive(false);
                pigeon.transform.GetChild(1).gameObject.SetActive(true);
                pigeon.GetComponent<PigeonFlock>().flocking = true;
            }
        }
    }

    IEnumerator FlyAway() {

        for (int i  = 0; i < 10000; i++) {
            transform.position += flyAwayDirection.normalized * flyAwaySpeed * Time.deltaTime;
            yield return null;
        }
    }
}
