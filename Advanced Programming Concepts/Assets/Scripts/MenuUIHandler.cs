using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        MainManger.Instance.unitColour = color;
    }
    
    private void Start()
    {
        Debug.Log("MainManger Instance at Start: " + MainManger.Instance);
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;


        ColorPicker.SelectColor(MainManger.Instance.unitColour);
    }
    
    public void clickStart()
    {
        Debug.Log("Start Was Pressed!");
        SceneManager.LoadScene("Main"); 
    }
         


    public void Exit()
    {
        MainManger.Instance.saveColour();
    #if UNITY_EDITOR
    //Makes It So It Will Exit Unity Editor Playmode.
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }



    public void SaveColorClicked()
    {
        MainManger.Instance.saveColour();
    }

    public void LoadColorClicked()
    {
        MainManger.Instance.loadColour();
        ColorPicker.SelectColor(MainManger.Instance.unitColour);
    }



}
