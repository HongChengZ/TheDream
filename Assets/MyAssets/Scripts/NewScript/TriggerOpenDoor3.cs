using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenDoor3 : MonoBehaviour
{

    public AudioSource HitSound;
    public AudioSource LeaveSound;
    public bool isTriggered = false;
    public GameObject Door;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable" && other.name == "right")
        {
            if (isTriggered == false)
            {

                HitSound.Play();
                Door.GetComponent<Door01>().OpentheDoor();
                isTriggered = true;
                Debug.Log("IN");
            }
 
     
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable" && other.name == "right")
        {
            LeaveSound.Play();
            isTriggered = false;
            Debug.Log("Out");
        }
    }

}


