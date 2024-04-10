using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text savedNameText;
    private const string playerNameKey = "Username";


    private void Start()
    {
        // Load the saved username when the game starts
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            string savedUsername = PlayerPrefs.GetString(playerNameKey);
            inputField.text = savedUsername;
            Debug.Log("Username loaded: " + savedUsername);

            // Update the TMP text component with the saved username
            UpdateSavedNameText();
        }
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SaveUsername()
    {
        if (inputField != null && !string.IsNullOrEmpty(inputField.text))
        {
            // Save the username to PlayerPrefs
            PlayerPrefs.SetString("Username", inputField.text);
            PlayerPrefs.Save();
            Debug.Log("Username saved: " + inputField.text);

            UpdateSavedNameText();
        }
    }

    public void LoadUsername()
    {
        // Check if the username exists in PlayerPrefs
        if (PlayerPrefs.HasKey("Username"))
        {
            // Load the username from PlayerPrefs and update the input field's text
            string savedUsername = PlayerPrefs.GetString("Username");
            inputField.text = savedUsername;
            Debug.Log("Username loaded: " + savedUsername);

            UpdateSavedNameText();
        }
    }

    private void UpdateSavedNameText()
    {
        if (savedNameText != null && PlayerPrefs.HasKey(playerNameKey))
        {
            string savedUsername = PlayerPrefs.GetString(playerNameKey);
            savedNameText.text = "Hello " + savedUsername + " !";
        }
    }

}
