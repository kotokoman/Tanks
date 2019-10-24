using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaScene : MonoBehaviour
{
    bool gameEnded = false;

    [SerializeField] private ScoreManager scoreManager;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AcessarScore;
    }

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

    void AcessarScore(Scene scene, LoadSceneMode mode)
    {
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AcessarScore;
    }
}
