using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float repeatTime = 3f;

    void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
