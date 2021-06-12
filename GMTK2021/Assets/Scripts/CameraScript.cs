using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameManager gameManager;
    public List<Transform> targets;
    public Vector3 offset;
    public Vector3 velocity;
    public float smoothTime = 0.3f;

    public void Start()
    {
        offset = new Vector3(0, 0, -10);
        for (int i = 0; i < gameManager.climbers.Count; i++)
        {
            Debug.Log(targets[i]);
            Debug.Log(gameManager.climbers[i].GetComponent<Transform>());

            targets[i] = gameManager.climbers[i].GetComponent<Transform>();
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (targets.Count == 0) return;
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    public Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
