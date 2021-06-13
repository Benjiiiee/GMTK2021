using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClimbersInput : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro textMeshPro;
    public Rigidbody2D myRB;

    public AudioSource myAudio;
    public AudioClip[] grippingClips;
    public AudioClip[] letGoClips;

    // phil sprite
    public Sprite climbingSprite;
    public Sprite swingLeft;
    public Sprite swingRight;

    public SpriteRenderer climberVisual;

    public bool forcedToMove = false;
    public float thrust = 0f;
    public Vector2 direction = Vector2.zero;
    //private bool canGrip = true;

    float velocity2D;
    public enum ClimbersKey
    {
        a,
        s,
        d,
        f, 
        k, 
        l,
        q,
        z,
        x,
        p
    }
    public ClimbersKey assosiatedKey;

    public KeyCode climbersKey;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        gameManager = gameManager.GetComponent<GameManager>();
        myRB = GetComponent<Rigidbody2D>();
        textMeshPro.color = Color.red;

        LetterUpdate();

        //phil
        //velocity2D = myRB.velocity.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(climbersKey))
        {
            Grip();
        }
        else if (Input.GetKeyUp(climbersKey))
        {
            LetGo();

        }

        //phil sprite switch
        velocity2D = myRB.velocity.x;
        if (velocity2D > 0)
        {
            climberVisual.sprite = swingRight; //phil
        }
        else if (velocity2D < 0)
        {
            climberVisual.sprite = swingLeft; //phil
        }
    }

    private void FixedUpdate()
    {
        if(forcedToMove) myRB.AddForce(direction * thrust, ForceMode2D.Impulse);
    }

    public void Grip()
    {
        climberVisual.sprite = climbingSprite; //phil

        myAudio.PlayOneShot(RandomClip(grippingClips));
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        gameManager.climbersHolding++;
        textMeshPro.color = Color.green;
        LetterUpdate();
    }
    public void LetGo()
    {
        if (!gameManager.climbersLocked)
        {
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            myAudio.PlayOneShot(RandomClip(letGoClips));

        }
        gameManager.climbersHolding--;
        textMeshPro.color = Color.red;

        switch (assosiatedKey)
        {
            case ClimbersKey.a:
                climbersKey = KeyCode.A;
                textMeshPro.text = "";
                break;
            case ClimbersKey.s:
                climbersKey = KeyCode.S;
                textMeshPro.text = "";
                break;
            case ClimbersKey.d:
                climbersKey = KeyCode.D;
                textMeshPro.text = "";
                break;
            case ClimbersKey.f:
                climbersKey = KeyCode.F;
                textMeshPro.text = "";
                break;
            case ClimbersKey.k:
                climbersKey = KeyCode.K;
                textMeshPro.text = "";
                break;
            case ClimbersKey.l:
                climbersKey = KeyCode.L;
                textMeshPro.text = "";
                break;
            case ClimbersKey.q:
                climbersKey = KeyCode.Q;
                textMeshPro.text = "";
                break;
            case ClimbersKey.z:
                climbersKey = KeyCode.Z;
                textMeshPro.text = "";
                break;
            case ClimbersKey.x:
                climbersKey = KeyCode.X;
                textMeshPro.text = "";
                break;
            case ClimbersKey.p:
                climbersKey = KeyCode.P;
                textMeshPro.text = "";
                break;
        }
    }
    public void GetMovement(float collThrust, Vector2 collDirection, bool collForcedToMove)
    {
        thrust = collThrust;
        direction = collDirection;
        forcedToMove = collForcedToMove;
    }
    public void ClearMovementValues()
    {
        thrust = 0;
        direction = Vector2.zero;
        forcedToMove = false;
    }

    public AudioClip RandomClip(AudioClip[] clipArray)
    {
        return clipArray[Random.Range(0, clipArray.Length)];
    }
    public void LetterUpdate() 
    {
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
            case ClimbersKey.k:
                climbersKey = KeyCode.K;
                textMeshPro.text = "K";
                break;
            case ClimbersKey.l:
                climbersKey = KeyCode.L;
                textMeshPro.text = "L";
                break;
            case ClimbersKey.q:
                climbersKey = KeyCode.Q;
                textMeshPro.text = "Q";
                break;
            case ClimbersKey.z:
                climbersKey = KeyCode.Z;
                textMeshPro.text = "Z";
                break;
            case ClimbersKey.x:
                climbersKey = KeyCode.X;
                textMeshPro.text = "X";
                break;
            case ClimbersKey.p:
                climbersKey = KeyCode.P;
                textMeshPro.text = "P";
                break;
        }
    }
}
