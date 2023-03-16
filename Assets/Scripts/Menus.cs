using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void TimedMode()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void AccelerationMode()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
