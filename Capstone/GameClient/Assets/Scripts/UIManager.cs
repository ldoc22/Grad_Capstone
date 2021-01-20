using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    public static UIManager instance;

    public GameObject StartMenu;
    public InputField usernameField;

    public InputField ChatInputBox;
    [SerializeField] private Text chatText;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance of UIManager alreadyt exists");
            Destroy(this);
        }

    }

    public void ConnectToServer()
    {
        StartMenu.SetActive(false);
        usernameField.interactable = false;
        Client.instance.ConnectToServer();
    }

    public void SendWorldChat()
    {
        ClientSend.SendWorldChat(ChatInputBox.text.ToString());
        chatText.text += $"\n{Client.instance.myId}: {ChatInputBox.text.ToString()}";
        ChatInputBox.text = "";
    }

    public void ReceiveWorldChat(int _id, string _msg)
    {
        chatText.text += $"\n{_id}: {_msg}"; 
    }


  
}
