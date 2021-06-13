using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    Transform tr;

    public bool canScale = false;
    public Vector3 targetNewScale;
    public float maxScaleDown;
    //public ClimbersInput coll;

    private void Start()
    {
        tr = transform;
        targetNewScale = new Vector3(-0.1f, -0.1f, 0f);
        maxScaleDown = 0.8f;
    }

    private void Update()
    {
        if (tr.localScale.x > 1)
        {
            tr.localScale = Vector3.one;
        }
        if (canScale)
        {
            tr.localScale += targetNewScale;
            if (tr.localScale.x < maxScaleDown)
            {
                canScale = false;
                targetNewScale = -targetNewScale;
            }
        }
        else
        {
            if (tr.localScale.x < 1)
            {
                canScale = false;
                tr.localScale += targetNewScale;
            }
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ClimbersInput>() != null)
        {
           canScale = true;
            targetNewScale = -targetNewScale;
        }
        
    }
}
