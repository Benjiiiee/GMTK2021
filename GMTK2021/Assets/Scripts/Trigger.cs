using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ClimbersInput rbToMove;
    public float triggerThrust = 20f;

    public Vector2 triggerDirection;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        rbToMove = collision.gameObject.GetComponent<ClimbersInput>();
        rbToMove.forcedToMove = true;
        rbToMove.thrust = triggerThrust;
        rbToMove.direction = triggerDirection;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        rbToMove.forcedToMove = false;
        rbToMove.thrust = 0f;
        rbToMove.direction = triggerDirection;
        rbToMove = null;
    }
}
