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

    [SerializeField] ChatManager chatManager;

    Vector3 trophyPos;
    
    void Start()
    {
        gameWonMenu.SetActive(false);
        trophyPos = new Vector3(0.0f, 1.05f, 136.8f);
        chatManager.SendMessageToChat("Welcome!", Message.MessageType.info);
        chatManager.SendMessageToChat("Press ENTER to Type in chat.", Message.MessageType.info);
        chatManager.SendMessageToChat("..And Press TAB to close the chat.", Message.MessageType.info);
        chatManager.SendMessageToChat("Sorry bout the bugs that needs fixing. Have fun!", Message.MessageType.info);
    }

    // Update is called once per frame
    void Update()
    {

        //game winning
        if(trophy.isCollected)
        {
            chatManager.SendMessageToChat("You have won the game.", Message.MessageType.info);
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
        chatManager.ClearChat();
        chatManager.SendMessageToChat("Trophy Equipped.", Message.MessageType.info);
        player.GetComponent<PlayerMovement>().ResetPosition();

        trophy.transform.SetParent(null);
        trophy.transform.position = trophyPos;
        trophy.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        gameWonMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }



}
