using UnityEngine;

public class ProjetilScript : MonoBehaviour
{    
    public float timeLimit = 1f; //variavel que define o tempo maximo que o projetil fica instanciado na scene
    private float timer = 0;     //variavel que recebe um "contador" de tempo

    private void Update()
    {
        timer += Time.deltaTime;     //atribui o tempo para a variavel timer
        
        if(timer >= timeLimit)    //verifica quando o tempo atingir o tempo maximo
        {
            timer = 0;      //reseta o timer
            Destroy(gameObject);    //destroi o projetil
        }
    }

    private void OnTriggerEnter(Collider other)     //verificar a colisão do projetil com outros objetos da scene
    {
        if(other.gameObject.tag == "Enemy") // verifica se o outro objeto no qual o projetil está colidindo tem a tag "Enemy"
        {

            other.gameObject.SetActive(false);     //seta a "atividade" do outro objeto como falso
            Destroy(gameObject);   // destroi o projetil
           
            ScoreManager score;     //variavel para instanciar o script de Score Manager
            
            score = GameObject.Find("Score").GetComponent<ScoreManager>();    //instancia o script ScoreManager atribuido ao game object Score
            score.Points = 1;     //retorna o valor para a variavel Points no ScoreManager
        }
    } 
}
