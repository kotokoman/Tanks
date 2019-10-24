using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    private Transform tr_Player;
    public float rotSpd, movSpd;

   void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), rotSpd * Time.deltaTime);

        transform.position += transform.forward * movSpd * Time.deltaTime;
    }
}
