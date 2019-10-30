using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaScene : MonoBehaviour
{
    bool gameEnded = false; //variavel para verificar se o jogo terminou

    public void EndGame()  //função chamada quando o HP do jogador for <= 0
    {
        if(!gameEnded) //verifica se o jogo ainda esta rodando
        {
            gameEnded = true; //seta o jogo para "terminado"

            SceneManager.LoadScene("GameOver"); //carrega a Scene de game over
        }
    }

    public void Restart() //função chamada no botão da tela de game over para o player jogar novamente
    {
        SceneManager.LoadScene("Gameplay"); //carrega a Scene do jogo
    }
}
