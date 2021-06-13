using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour
{
    Transform tr;

    bool canScale = false;
    Vector3 targetNewScale;
    public float maxScaleDown = 0.5f;

    private void Start()
    {
        tr = transform;
        targetNewScale = new Vector3(-0.1f, -0.1f, 0f);
    }

    private void Update()
    {
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
        if(tr.localScale.x > 1)
        {
            tr.localScale = Vector3.one;
            targetNewScale -= targetNewScale;
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ClimbersInput>() != null)
        {
           canScale = true;
        }
        
    }
}
