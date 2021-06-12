using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> climbers;

    public int climbersTotal;
    public int climbersHolding;

    private void Start()
    {
        
    }

    private void Update()
    {
        CheckClimbersNumber();
    }

    public void CheckClimbersNumber()
    {
        if (climbersHolding < (climbersTotal / 2))
        {
            Debug.Log("YOU DIED");
        }
    }
}
