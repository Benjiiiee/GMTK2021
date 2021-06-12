using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ClimbersInput> climbers;

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
        if(climbersLocked)
        {
            if(climbersHolding == climbersTotal)
            {
                climbersLocked = false;
            }
        }

        if (climbersHolding < (climbersTotal / 2))
        {
            Debug.Log("YOU DIED");
        }
    }

    public void CheckHold()
    {

    }
}
