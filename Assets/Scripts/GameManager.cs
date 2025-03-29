using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    int nTrophiesCollected = 0;

    [SerializeField] TextMeshProUGUI trophiesCollected;
    [SerializeField] AcquireTrophy trophy;
    [SerializeField] GameObject gameWonMenu;
    [SerializeField] GameObject player;



    Vector3 startingPos;
    Vector3 trophyPos;
    
    void Start()
    {
        gameWonMenu.SetActive(false);
        startingPos = new Vector3(0, 2, 0);
        trophyPos = new Vector3(2.5f, 1.05f, 60.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(trophy.isCollected)
        {
            nTrophiesCollected++;
            trophiesCollected.text = "x " + nTrophiesCollected;
            gameWonMenu.SetActive(true);
            trophy.isCollected = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void RestartGame()
    {
        player.transform.position = startingPos;

        trophy.transform.SetParent(null);
        trophy.transform.position = trophyPos;

        gameWonMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
