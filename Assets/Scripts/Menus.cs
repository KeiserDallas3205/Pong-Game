using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // ints to choose which scene we're loading
    public int timedModeScene;
    public int accelerationModeScene;

    public void TimedMode()
    {
        SceneManager.LoadScene(timedModeScene);
    }
    public void AccelerationMode()
    {
        SceneManager.LoadScene(accelerationModeScene);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
