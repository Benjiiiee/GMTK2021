using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource mySouce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mySouce.Play();
        gameManager.NextLevel();
    }


}
