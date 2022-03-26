using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMainScene : MonoBehaviour
{

    public TMP_Text highScoreText;
    public TMP_InputField nameInputField;
    public Button startButton;
    public Button exitButton;

    public void StartNew()
    {
        if(nameInputField.text != "")
        {
            InputName();
            SceneManager.LoadScene(1);

        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void InputName()
    {        
        DataManager.instance.nameInput = nameInputField.text;   
        
    }
}
