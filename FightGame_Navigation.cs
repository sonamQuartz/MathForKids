using UnityEngine.SceneManagement;
using UnityEngine;

public class FightGame_Navigation : MonoBehaviour
{
    public GameObject endScreensaver;

    public void Back()
    {
        endScreensaver.SetActive(true);
        Invoke("PreviousScene", 1);
    }

    public void Home()
    {
        endScreensaver.SetActive(true);
        Invoke("HomeScene", 1);
    }

    void HomeScene()
    {
        SceneManager.LoadScene("GameModeSelection");
    }

    void PreviousScene()
    {
        SceneManager.LoadScene("MathActionSelection");
    }
}
