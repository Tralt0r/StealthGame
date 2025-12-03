using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f; //3 minutes
    public bool timerIsRunning = true;
    public GameEnding gameEnding;  //GameEnd script so I can kill John Lemon
    private VisualElement m_EndScreen;
    private VisualElement m_CaughtScreen;
    public AudioSource caughtAudio;
    public UIDocument uiDocument;

    public TMP_Text tmpText;

    void Start()
    {
        m_EndScreen = uiDocument.rootVisualElement.Q<VisualElement>("EndScreen");
        m_CaughtScreen = uiDocument.rootVisualElement.Q<VisualElement>("CaughtScreen");
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                //Prevent going below zero
                if (timeRemaining < 0)
                    timeRemaining = 0;

                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;

                //Call the EndLevel
                gameEnding.EndLevel(m_CaughtScreen, true, caughtAudio);
            }
        }
    }

    //formats timer properly
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        string formatted = $"{minutes:00}:{seconds:00}";

        if (tmpText != null)
            tmpText.text = formatted;
    }
}