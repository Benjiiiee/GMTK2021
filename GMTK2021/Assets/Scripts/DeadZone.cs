using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip[] myClips;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameManager.blockInputs)
        {
            mySource.PlayOneShot(RandomClip(myClips));
            gameManager.Death();
        }
    }

    public AudioClip RandomClip(AudioClip[] clipArray)
    {
        return clipArray[Random.Range(0, clipArray.Length)];
    }
}
