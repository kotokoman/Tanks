using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;          //variavel para guardar o object do inimigo
    public float repeatTime = 3f;     //tempo para repetir o spawn

    void Start()
    {
        InvokeRepeating("Spawn", 2f, repeatTime);  //parametros para repetir os spawns
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);    //instanciar os inimigos na posição dos spawners
    }
}
