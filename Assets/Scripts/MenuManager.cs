using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void timedMode() { print("pressed timedMode");  SceneManager.LoadScene(1); }

    public void accelerationMode() { print("pressed accelerationMode"); SceneManager.LoadScene(2); }

    public void quitGame() { print("pressed quit"); Application.Quit(); }
}
