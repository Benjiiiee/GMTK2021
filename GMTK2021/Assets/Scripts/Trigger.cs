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

    public bool timerIsRunningA;
    public float cooldownTimer;
    public float cooldownTimer2;
    public float cooldown;

    private void Start()
    {
        triggerParticleSystem = GetComponentInChildren<ParticleSystem>();
        mainParticule = triggerParticleSystem.main;
        activateCollider = triggerParticleSystem.isPlaying;
        triggerParticleSystem.Play();
        cooldownTimer = cooldown;
        cooldownTimer2 = cooldown;
    }

    private void Update()
    {
        activateCollider = triggerParticleSystem.isPlaying;
        if (!activateCollider)
        {
            if (cooldownTimer > 0) cooldownTimer -= Time.deltaTime;
            else
            {
                cooldownTimer = 0;
                if (cooldownTimer2 > 0)
                {
                    cooldownTimer2 -= Time.deltaTime;
                }
                else
                {
                    cooldownTimer2 = cooldown;
                    cooldownTimer = cooldown;
                    triggerParticleSystem.Play();
                }
            }
        }
        
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
