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


    //MANAGING MESSAGES
    List<Message> messages = new List<Message>();
    [SerializeField] GameObject chatPanel, textObject;
    [SerializeField] TMP_InputField chatBox;
    int maxMessages = 25;
    [SerializeField] Color infoColor, playerMessageColor;

    Vector3 startingPos;
    Vector3 trophyPos;
    
    void Start()
    {
        chatBox.gameObject.SetActive(false);
        gameWonMenu.SetActive(false);
        startingPos = new Vector3(0, 2, 0);
        trophyPos = new Vector3(2.5f, 1.05f, 60.0f);
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



        //chatbox
        if(Input.GetKeyDown(KeyCode.Return) && !chatBox.IsActive())
        {
            chatBox.gameObject.SetActive(true);
            chatBox.ActivateInputField();
        }
        else if(chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if(messages.Count >= maxMessages)
        {
            Destroy(messages[0].textObject.gameObject);
            messages.Remove(messages[0]);
        }
        Message message = new Message();
        message.text = text;

        GameObject newTextObj = Instantiate(textObject, chatPanel.transform);
        message.textObject = newTextObj.GetComponent<TextMeshProUGUI>();

        message.textObject.text = message.text;

        if (messageType == Message.MessageType.info)
        {
            message.textObject.color = infoColor;
        }
        else
        {
            message.textObject.color = playerMessageColor;
        }

        messages.Add(message);
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

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
    public MessageType messageType;
    public enum MessageType
    {
        info,
        playerMessage
    }
}
