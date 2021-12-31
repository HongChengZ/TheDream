using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCtoMENU : MonoBehaviour
{
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene - 2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
