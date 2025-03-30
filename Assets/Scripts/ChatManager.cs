using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public GameObject scrollView;

    public Color playerMessage, info;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    // Update is called once per frame
    private void Start()
    {
        scrollView.gameObject.SetActive(false);
    }
    void Update()
    {
        if(chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat("Me: " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }
        else
        {
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
                scrollView.gameObject.SetActive(true);

            }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            scrollView.SetActive(false);
        }

    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        scrollView.gameObject.SetActive(true);

        if(messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMessage = new Message();
        newMessage.text = text;

        

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch(messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
 
        return color;
    }

    public void ClearChat()
    {
        foreach(Message msg in messageList)
        {
            Destroy(msg.textObject.gameObject);
        }
        messageList.Clear();
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;
    public enum MessageType
    {
        playerMessage,
        info
    }
}