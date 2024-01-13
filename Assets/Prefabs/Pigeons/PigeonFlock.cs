using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonFlock : MonoBehaviour
{   
    public PigeonFlockingManager flockManager;
    public bool flocking = false;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(flockManager.minSpeed, flockManager.maxSpeed);    
    }

    // Update is called once per frame
    void Update()
    {   if (flocking) {
            if (Random.Range(0, 100) < 10) {

                speed = Random.Range(flockManager.minSpeed, flockManager.maxSpeed);    
            }

            // if (Random.Range(0, 100) < 10) {
            ApplyFlockingRules();
            // }

            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }

    private void ApplyFlockingRules() {
        GameObject[] allPigeons = flockManager.allPigeons;


        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;

        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;


        foreach (GameObject pigeon in allPigeons) {

            if (pigeon != this.gameObject) {
                nDistance = Vector3.Distance(pigeon.transform.position, this.transform.position);

                if (nDistance <= flockManager.neighborDistance) {

                    vcenter += pigeon.transform.position;
                    groupSize++;

                    if (nDistance <= flockManager.avoidanceDistance) {
                        vavoid += this.transform.position - pigeon.transform.position;
                    }

                    PigeonFlock otherFlock = pigeon.GetComponent<PigeonFlock>();
                    gSpeed += otherFlock.speed;
                }   
            }
        }

        if (groupSize > 0) {
            vcenter = vcenter / groupSize + (flockManager.transform.position - this.transform.position);
            speed = gSpeed / groupSize;

            if (speed > flockManager.maxSpeed) {
                speed = flockManager.maxSpeed;
            }

            Vector3 direction = (vcenter + vavoid) - transform.position;
            
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockManager.rotationSpeed * Time.deltaTime);
            }
        }


    }
}
