using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraAnimation : MonoBehaviour
{
    private Animator animator;
    //MainMenu Menu;
    void Start()
    {
        animator = GetComponent<Animator>();      
    }

    public void PlayAnimation()
    {
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
}
