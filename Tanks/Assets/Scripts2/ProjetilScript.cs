using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour
{    
    public float timeLimit;
    private float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;       
        
        if(timer >= timeLimit)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }

    //Detectar uma colisão
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {

            other.gameObject.SetActive(false);
            Destroy(gameObject);
           
            ScoreManager score;
            
            score = GameObject.Find("Score").GetComponent<ScoreManager>();
            score.Points = 1;
        }
    } 
}
