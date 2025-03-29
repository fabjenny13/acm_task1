using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    int nTrophiesCollected = 0;
    Text trophiesCollected;
    AcquireTrophy trophy;
    void Start()
    {
        trophy = GetComponent<AcquireTrophy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trophy.isCollected)
        {
            nTrophiesCollected++;
            trophiesCollected.text = "x " + nTrophiesCollected;
        }
    }
}
