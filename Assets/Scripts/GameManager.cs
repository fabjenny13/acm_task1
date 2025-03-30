using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //TROPHY AND GAME RESTART
    int nTrophiesCollected = 0;

    [SerializeField] TextMeshProUGUI trophiesCollected;
    [SerializeField] AcquireTrophy trophy;
    [SerializeField] GameObject gameWonMenu;
    [SerializeField] GameObject player;

   

    Vector3 trophyPos;
    
    void Start()
    {
        gameWonMenu.SetActive(false);
        trophyPos = new Vector3(0.0f, 1.05f, 136.8f);
    }

    // Update is called once per frame
    void Update()
    {

        //game winning
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
        player.GetComponent<PlayerMovement>().ResetPosition();

        trophy.transform.SetParent(null);
        trophy.transform.position = trophyPos;

        gameWonMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }



}
