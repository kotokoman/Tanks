using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float velocidade;

    private Rigidbody m_Rigidbody;
    
   
    private void Start()
    {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
        Rotation();
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = -0.5f;
            transform.Rotate(rotation * velocidade * 2);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y = 0.5f;
           transform.Rotate(rotation * velocidade * 2);
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
           transform.Translate(0, 0, 0.1f * velocidade);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.1f * velocidade);
        }
    }
}

