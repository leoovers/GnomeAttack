using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawn : MonoBehaviour
{
    public GameObject bees;
    public GameObject bees2;
    private GameObject newBee;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnBees()
    {
        newBee = Instantiate(bees, spawnPoint.transform.position, Quaternion.identity);
        newBee = Instantiate(bees2, spawnPoint.transform.position, Quaternion.identity);

    }
}
