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
        if (Input.GetKeyDown(KeyCode.R))
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

        if (climbersHolding < (climbersTotal / 2))
        {
            //Debug.Log("YOU DIED");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

}
