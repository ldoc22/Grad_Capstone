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

    public Dropdown channelDropDown;
    private int channelIndex;
    

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
        if(channelDropDown != null)
        {
            InititalizeDropDown();
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
        ClientSend.SendWorldChat(channelIndex,ChatInputBox.text.ToString());
        chatText.color = ChannelColor(channelIndex);
        chatText.text += $"\n{Client.instance.myId}: {ChatInputBox.text.ToString()}";
        ChatInputBox.text = "";
    }

    public void ReceiveWorldChat(int _id,int _channel, string _msg)
    {
        chatText.color = ChannelColor(_channel);
        chatText.text += $"\n{_id}: {_msg}"; 
    }






    ////////
    
    public Color ChannelColor(int i)
    {
        switch (i)
        {
            case 0:
                return Color.black;
                break;
            case 1:
                return Color.red;
                break;
            default:
                return Color.yellow;
                break;

        }
    }

    public void OnChannelChange(int index)
    {
        channelIndex = index;

        switch (index) 
        {
            
        }

    }

    public void InititalizeDropDown()
    {
        channelIndex = 0;
        List<string> channelNames = new List<string>(System.Enum.GetNames(typeof(ChatChannel)));
        channelDropDown.AddOptions(channelNames);
    }
  
}
