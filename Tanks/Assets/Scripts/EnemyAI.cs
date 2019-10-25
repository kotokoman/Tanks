using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private Transform trPlayer;        //variavel para armazenar posição do jogador
    public float rotSpd;               //variavel para definir a velocidade de rotação do inimigo
    public float movSpd;               //variavel para definir a velocidade de movimento do inimigo

    void Start()
    {
        trPlayer = GameObject.FindGameObjectWithTag("Player").transform; //armazenando a posição do player
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpd * Time.deltaTime); //rotacionando o inimigo para ficar sempre olhando para o player

        transform.position += transform.forward * movSpd * Time.deltaTime; //movendo o inimigo para a frente (seguindo o player)
    }
}
