using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public GameObject[] vehiclePrefabs;
    public int numVehiclePrefabs;

    public float vehicleSpawnTime;

    public float vehicleTimeToLive = 5f;
    // Update is called once per frame
    void Start() {
        StartCoroutine(SpawnVehicle());
    }

    IEnumerator SpawnVehicle() {


        while(true) {

            GameObject vehicle = Instantiate(vehiclePrefabs[Random.Range(0, numVehiclePrefabs)], transform.position, Quaternion.identity);
            vehicle.GetComponent<VehicleControl>().direction = transform.forward;
            StartCoroutine(DestroyVehicle(vehicle));
            yield return new WaitForSeconds(vehicleSpawnTime);
        }
    }

    IEnumerator DestroyVehicle(GameObject vehicle) {

        yield return new WaitForSeconds(vehicleTimeToLive);
        Destroy(vehicle);
    }
}
