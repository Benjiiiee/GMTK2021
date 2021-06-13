using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public HingeJoint2D hook, linkPrefab;
    Rigidbody2D previousLink;
    public int nbLinks = 7;
    public HingeJoint2D linkedClimber;
    public List<Transform> hingeTr;
    public LineRenderer lineRenderer;
    public float ropeWidth = 0.03f;
    public Vector3[] ropePos;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GenerateRope();
        DrawRope();
        ropePos = new Vector3[nbLinks + 1];
    }

    private void Update()
    {
        UpdateRope();
    }

    public void GenerateRope()
    {
        previousLink = hook.GetComponent<Rigidbody2D>();
        hingeTr.Add(previousLink.transform);

        for (int i = 0; i < nbLinks; i++)
        {
            HingeJoint2D temp = Instantiate(linkPrefab, transform);
            temp.connectedBody = previousLink;

            previousLink = temp.GetComponent<Rigidbody2D>();
            hingeTr.Add(previousLink.transform);
        }

        if(linkedClimber != null)
        {
            linkedClimber.connectedBody = previousLink;
        }
    }

    public void DrawRope()
    {
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;
        lineRenderer.positionCount = hingeTr.Count;
    }

    public void UpdateRope()
    {
        for (int i = 0; i < ropePos.Length; i++)
        {
            ropePos[i] = hingeTr[i].position;//+ new Vector3(0,0,-38f);
        }

        lineRenderer.SetPositions(ropePos);
    }

}
