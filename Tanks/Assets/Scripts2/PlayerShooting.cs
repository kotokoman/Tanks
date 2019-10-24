using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Rigidbody projetil;
    public Transform saida;

    public float shotSpeed = 75f;

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
       {
            Shoot();
       }
    }

    void Shoot()
    {
       Rigidbody instanciaProjetil;
       instanciaProjetil = Instantiate(projetil, saida.position, saida.rotation) as Rigidbody;
       instanciaProjetil.velocity = shotSpeed * saida.forward;
    }
}