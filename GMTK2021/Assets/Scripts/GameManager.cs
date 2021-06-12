using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> climbers;

    public ClimbersInput.ClimbersKey a;

    private void Start()
    {
        a = climbers[0].GetComponent<ClimbersInput>().assosiatedKey;
    }
}
