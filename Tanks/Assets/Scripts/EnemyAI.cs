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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(trPlayer.position - transform.position), rotSpd * Time.deltaTime);

        transform.position += transform.forward * movSpd * Time.deltaTime;
    }
}
