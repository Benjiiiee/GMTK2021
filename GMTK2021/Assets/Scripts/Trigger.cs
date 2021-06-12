using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ClimbersInput rbToMove;
    public float triggerThrust = 20f;

    public Vector2 triggerDirection;

    public ParticleSystem triggerParticleSystem;
    public ParticleSystem.MainModule mainParticule;
    public bool activateCollider;

    private void Start()
    {
        triggerParticleSystem = GetComponentInChildren<ParticleSystem>();
        mainParticule = triggerParticleSystem.main;
        activateCollider = triggerParticleSystem.isPlaying;
    }

    private void Update()
    {
        activateCollider = triggerParticleSystem.isPlaying;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activateCollider) { 
            rbToMove = collision.gameObject.GetComponent<ClimbersInput>();
            rbToMove.forcedToMove = true;
            rbToMove.thrust = triggerThrust;
            rbToMove.direction = triggerDirection;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (rbToMove != null)
        {
            rbToMove.forcedToMove = false;
            rbToMove.thrust = 0f;
            rbToMove.direction = triggerDirection;
            rbToMove = null;
        }
        
    }
}
