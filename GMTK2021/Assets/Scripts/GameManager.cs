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
    public bool blockInputs = false;
    public AudioSource deathJingle;

    private void Start()
    {
        deathJingle = GetComponent<AudioSource>();
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
        if (Input.GetKeyDown(KeyCode.R) && !blockInputs)
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
        blockInputs = true;
        deathJingle.Play();
        for (int i = 0; i < climbers.Count; i++)
        {
            climbers[i].LetGo();
        }
        FadeOut();
        Invoke("Reload", 1.5f);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        blockInputs = true;
        for(int i = 0; i < climbers.Count; i++)
        {
            climbers[i].Grip();
        }
        Invoke("FadeOut", 1.5f);
        Invoke("LoadNextLevel", 3f);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
