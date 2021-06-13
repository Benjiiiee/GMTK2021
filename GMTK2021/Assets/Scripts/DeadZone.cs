using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public AudioSource clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        clip.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
