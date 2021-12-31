using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door01 : MonoBehaviour
{
    public GameObject Exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpentheDoor()
    {
        GetComponent<Animation>().Play();
    }
}
