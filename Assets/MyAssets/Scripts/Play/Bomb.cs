using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Bomb : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource recording;

    bool isTicking = false;
    public Image whiteFade;

    //timeRemaining = 10:05 = 605
    private float timeRemaining = 605;
    bool timeIsRunning;
    public TextMeshProUGUI timeText;

    void Start()
    {
        whiteFade.canvasRenderer.SetAlpha(0f);

        StartCoroutine(PlayBackgroundMusic(8f));      
    }

    void Update()
    {
        StartCoroutine(DisplayTime(timeRemaining));
        ActivateBomb();
        TimerTicking();
    }

    IEnumerator DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        //62 % 60 = 1min2sec; 125 & 60 = 2min5sec; 46 % 60 = 46sec
        //float milliSeconds = (timeToDisplay % 1) * 1000;

        yield return new WaitForSeconds(3f);
        timeIsRunning = true;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ActivateBomb()
    {
        if (timeIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isTicking = true;
                timeIsRunning = false;
            }
        }
        //When the music ends, the dream ends as well, the protagonist wakes up, game over
        //Set a countdown timer with the music track. When the timeRemaining arrives a certain number
        //isTicking becomes true.
        //When music is about to end, the bomb activates: isTicking = true;
    }

    void TimerTicking()
    {
        if (isTicking == true)
        {
            StartCoroutine(BombCheck());
            //timeRemaining--;
            //Debug.Log(timeRemaining);
        }

        if (timeRemaining < 0)
        {
            isTicking = false;
        }
    }

    IEnumerator BombCheck()
    {
        yield return new WaitUntil(IsExplosion);
        whiteFade.CrossFadeAlpha(2, 5, false);
        yield return new WaitForSeconds(4f);
        backgroundMusic.Stop();
        yield return new WaitForSeconds(2f);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 2);
    }

    bool IsExplosion()
    {
        if (timeRemaining > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    IEnumerator PlayBackgroundMusic(float waitTime)
    {
        backgroundMusic.volume = 0.1f;
        yield return new WaitForSeconds(waitTime);
        backgroundMusic.Play();
        recording.Play();
        yield return new WaitForSeconds(31f);
        recording.Stop();
        backgroundMusic.volume = 0.2f;
    }
}
