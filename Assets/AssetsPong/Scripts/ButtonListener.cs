using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListener : MonoBehaviour
{
    Button playButton, levelButton, menuButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.FindGameObjectWithTag("BPlay").GetComponent<Button>();

        playButton.onClick.AddListener(() => PlayButton());
    }
    void PlayButton()
    {
        Debug.Log("Funciona AddListener!!");
    }

    void LevelButton()
    {
        
    }

    void MenuButton()
    {
        
    }


}
