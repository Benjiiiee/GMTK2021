using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public AudioSource clip;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        clip.Play();
        gameManager.Death();
    }
}
