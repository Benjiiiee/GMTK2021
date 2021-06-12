using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<ClimbersInput> climbers;
    public EndPoint endPoint;


    public int climbersTotal;
    public int climbersHolding = 0;
    public bool climbersLocked = true;

    private void Start()
    {
        climbersTotal = climbers.Count;
    }

    private void Update()
    {
        CheckClimbersNumber();
        
    }

    public void CheckClimbersNumber()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
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
}
