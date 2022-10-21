﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    private Animator animator;
    //MainMenu Menu;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("ClickPlay", false);
    }

    public void PlayAnimation()
    {
        Debug.Log("play");
        animator.SetBool("ClickPlay", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "door_lvl1")
        {
            //Menu = GameObject.Find("Main Camera").GetComponent<MainMenu>();
            PlayGame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}