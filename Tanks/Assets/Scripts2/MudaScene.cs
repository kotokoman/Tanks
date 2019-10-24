using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaScene : MonoBehaviour
{
    bool gameEnded = false;

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;

            SceneManager.LoadScene("GameOver");
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
