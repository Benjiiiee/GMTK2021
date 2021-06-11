using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public HingeJoint2D hook, linkPrefab;
    Rigidbody2D previousLink;
    public int nbLinks = 7;
    public HingeJoint2D linkedClimber;

    void Start()
    {
        GenerateRope();
    }

    public void GenerateRope()
    {
        previousLink = hook.GetComponent<Rigidbody2D>();

        for (int i = 0; i < nbLinks; i++)
        {
            HingeJoint2D temp = Instantiate(linkPrefab, transform);
            temp.connectedBody = previousLink;

            previousLink = temp.GetComponent<Rigidbody2D>();
        }

        if(linkedClimber != null)
        {
            linkedClimber.connectedBody = previousLink;
        }
    }

}
