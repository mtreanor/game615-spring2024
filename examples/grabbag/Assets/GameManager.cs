using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Action FadeStarted;
    public static Action FadeComplete;

    [SerializeField]
    GameObject canvasObject;

    [SerializeField]
    Image fadeImage;

    [SerializeField]
    TMP_Text scoreText;

    int score = 0;

    private void OnEnable()
    {
        if (Instance != null)
        {
            Debug.Log("We got a problem");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());

        scoreText.text = score.ToString();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(canvasObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();

        if (score > 3)
        {
            SceneManager.LoadScene("Level2");
        }
    }

    IEnumerator FadeIn()
    {
        // Announce to anyone listening that we have started to fade
        FadeStarted?.Invoke();

        // Set up the UI element to be fully faded turned on. 
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(
                        fadeImage.color.r,
                        fadeImage.color.g,
                        fadeImage.color.b,
                        1
                    );


        // This is the part where we, a little bit at a time, turn down the alpha of
        // the image creating the effect that the scene is fading in.
        while (fadeImage.color.a > 0)
        {
            fadeImage.color = new Color(
                fadeImage.color.r,
                fadeImage.color.g,
                fadeImage.color.b,
                fadeImage.color.a - 0.5f * Time.deltaTime
            );

            // This is the part that makes this function a "coroutine". It pretty much
            // says, "I'm done for now Unity, go do whatever else you were doing, but return
            // right to this point next chance you get".
            yield return null;
        }

        // Do this just to get the UI element out of the way.
        fadeImage.gameObject.SetActive(false);

        // Announce to anyone listening that we are done fading.
        FadeComplete?.Invoke();
    }
}
