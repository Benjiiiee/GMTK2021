using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbersInput : MonoBehaviour
{
    public MonoBehaviour gameManager;
    //private bool canGrip = true;
    public enum ClimbersKey
    {
        a,
        s,
        d,
        f
    }
    public ClimbersKey assosiatedKey;

    public KeyCode climbersKey;
    // Start is called before the first frame update
    void Start()
    {
        switch (assosiatedKey)
        {
            case ClimbersKey.a:
                climbersKey = KeyCode.A;
                break;
            case ClimbersKey.s:
                climbersKey = KeyCode.S;
                break;
            case ClimbersKey.d:
                climbersKey = KeyCode.D;
                break;
            case ClimbersKey.f:
                climbersKey = KeyCode.F;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(climbersKey))
        {
            Grip();
        }
        else if(Input.GetKeyUp(climbersKey))
        {
            LetGo();
        }
    }

    public void Grip()
    {
        /*if (canGrip)
        {*/
            Debug.Log("IM AM GRIPPING");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
       // }     
    }
    public void LetGo()
    {
       /* if (!canGrip)
        {*/
            Debug.Log("IM AM NOT GRIPPING");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //}
    }
}
