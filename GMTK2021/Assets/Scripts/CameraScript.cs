using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameManager gameManager;
    public List<Transform> targets;
    public Vector3 offset;
    public Vector3 velocity;
    public float smoothTime = 0.3f;

    public Transform clampY;
    public TextMeshPro timer;
    public Timer timerObject;

    public void Start()
    {
        offset = new Vector3(0, 0, -10);
        for (int i = 0; i < gameManager.climbers.Count; i++)
        {
            targets.Add(gameManager.climbers[i].GetComponent<Transform>());
        }
        
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0) return;
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);


        //Phil Cam boundary
        if (this.transform.position.x < 0.25f || this.transform.position.x > 12.20)
        {
            this.transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, 0.25f, 12.20f), transform.position.y, transform.position.z
            );
        }
        if (this.transform.position.y < clampY.position.y)
        {
            this.transform.position = new Vector3
            (
                transform.position.x, Mathf.Clamp(transform.position.y, clampY.position.y, 1000.0f), transform.position.z
            );
        }
    }

    public Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
