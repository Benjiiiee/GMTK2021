using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClimbersInput : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro textMeshPro;
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
        gameManager.climbersTotal++;
        textMeshPro = GetComponent<TextMeshPro>();
        gameManager = gameManager.GetComponent<GameManager>();

        switch (assosiatedKey)
        {
            case ClimbersKey.a:
                climbersKey = KeyCode.A;
                textMeshPro.text = "A";
                break;
            case ClimbersKey.s:
                climbersKey = KeyCode.S;
                textMeshPro.text = "S";
                break;
            case ClimbersKey.d:
                climbersKey = KeyCode.D;
                textMeshPro.text = "D";
                break;
            case ClimbersKey.f:
                climbersKey = KeyCode.F;
                textMeshPro.text = "F";
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
        gameManager.climbersHolding++;
       // }     
    }
    public void LetGo()
    {
       /* if (!canGrip)
        {*/
            Debug.Log("IM AM NOT GRIPPING");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameManager.climbersHolding--;
        //}
    }
}
