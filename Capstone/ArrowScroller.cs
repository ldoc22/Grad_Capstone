using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowScroller : MonoBehaviour
{
    
    public Text Title;
    public Text text;

    public Button leftButton, rightButton;
    

    public void Init(CharacterModelSwitch _cms, int idx)
    {
        leftButton.onClick.AddListener(() => _cms.lists[idx].nextItem(true));
        rightButton.onClick.AddListener(() => _cms.lists[idx].nextItem(false));
        Title.text = _cms.lists[idx].name;
    }
   

    

}
