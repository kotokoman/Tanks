using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody projetil;          // rigidbody do prefab do projetil
    public Transform saida;             // empty object para marcar a posição da saída do projetil

    public float shotSpeed = 75f;       // velocidade do projetil

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            Shoot();
       }
    }

    void Shoot()  // função para instanciar o projetil na posição e rotação da saída e atribuir a velocidade e direção do projetil
    {
       Rigidbody instanciaProjetil;
       instanciaProjetil = Instantiate(projetil, saida.position, saida.rotation) as Rigidbody;
       instanciaProjetil.velocity = shotSpeed * saida.forward;
    }
}