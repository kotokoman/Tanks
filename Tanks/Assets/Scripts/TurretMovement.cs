using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{

    public float velocidade;

    private Rigidbody m_Rigidbody;


    private void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = -0.5f;
            transform.Rotate(rotation * velocidade * 2);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = 0.5f;
            transform.Rotate(rotation * velocidade * 2);
        }
    }
}
