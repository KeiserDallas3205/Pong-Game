using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    float currTime = 0f;
    float startTime = 30f;

    [SerializeField] TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= 1 * Time.deltaTime;
        timerText.text = currTime.ToString("0");

        if (currTime <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
