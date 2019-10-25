using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{

    public float rotSpd = 3.5f;         //velocidade de rotação

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))     //verifica se o botao left arrow ta sendo pressionado
        {
            Vector3 rotation = transform.rotation.eulerAngles;         //
            rotation.y = -0.5f;                                        //
            transform.Rotate(rotation * rotSpd * 2);                   // rotaciona a turret no eixo Y para a esquerda
        }

        if (Input.GetKey(KeyCode.RightArrow))        //verifica se o botao right arrow ta sendo pressionado
        {
            Vector3 rotation = transform.rotation.eulerAngles;         //
            rotation.y = 0.5f;                                         //
            transform.Rotate(rotation * rotSpd * 2);                   // rotaciona a turret no eixo Y para a direita
        }
    }
}
