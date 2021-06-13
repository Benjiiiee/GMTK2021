using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<ClimbersInput> climbers;
    public EndPoint endPoint;


    public int climbersTotal;
    public int climbersHolding = 0;
    public bool climbersLocked = true;
    public CanvasGroup fade;
    public bool fadeIn = false;
    public bool fadeOut = false;
    public float fadeSpeed = 0.1f;
    public bool dead = false;

    private void Start()
    {
        climbersTotal = climbers.Count;
        fade.alpha = 1f;
        FadeIn();
    }

    private void Update()
    {
        CheckClimbersNumber();
        if(fadeIn)
        {
            fade.alpha -= fadeSpeed * Time.deltaTime;
            if (fade.alpha <= 0)
                fadeIn = false;
        }

        if(fadeOut)
        {
            fade.alpha += fadeSpeed * Time.deltaTime;
            if (fade.alpha >= 1)
                fadeOut = false;
        }
    }

    public void CheckClimbersNumber()
    {
        if (Input.GetKeyDown(KeyCode.R) && !dead)
        {
            fade.alpha = 1f;
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        if (climbersLocked)
        {
            if(climbersHolding == climbersTotal)
            {
                climbersLocked = false;
            }
        }
    }

    public void CheckHold()
    {

    }

    public void FadeIn()
    {
        fadeOut = false;
        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeIn = false;
        fadeOut = true;
    }

    public void Death()
    {
        dead = true;
        FadeOut();
        Invoke("Load", 1.5f);
    }

    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
