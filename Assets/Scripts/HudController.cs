using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    bool hasBeenCalled;
    
    
    public static HudController instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;


    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (F)";
        interactionText.gameObject.SetActive(true);
    }
    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 5) 
            {
                if (!hasBeenCalled)
                {
                    hasBeenCalled = true;
                    CallRichard();
                }
            }
        }
        else
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(ShowTimer(0.2f));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(HideTimer(3f));
        }

        
    }

    private void CallRichard()
    {
        
        StartCoroutine(ShowTimer(0.2f));

        //Faire venir richard vers le bureau
    }

    private IEnumerator ShowTimer(float duration)
    {
        float initialAlpha = timerText.color.a;
        float targetAlpha = 1f;
        float alphaChangePerSecond = (targetAlpha - initialAlpha) / duration;
        while (timerText.color.a < targetAlpha)
        {
            Color color = timerText.color;
            color.a += alphaChangePerSecond * Time.deltaTime;
            timerText.color = color;
            

            yield return null;
        }

        timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, 1f);

        yield return new WaitForSeconds(3000);


    }

    private IEnumerator HideTimer(float duration)
    {
        if (remainingTime > 10)
        {
            float initialAlpha = timerText.color.a;
            float targetAlpha = 0f;
            float alphaChangePerSecond = ( initialAlpha - targetAlpha) / duration;
            while (timerText.color.a > targetAlpha)
            {
                Color color = timerText.color;
                color.a -= alphaChangePerSecond * Time.deltaTime;
                timerText.color = color;


                yield return null;
            }

            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, 0f);
        }
    }

    public void DecreaseTimer(int Cost)
    {
        StartCoroutine(ShowTimer(0.2f));
        remainingTime -= Cost;



    }

    
}
