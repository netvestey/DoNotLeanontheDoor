using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSystem : MonoBehaviour
{
    public GameObject footsteps;

    private void Start()
    {
        footsteps.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            footstep();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            footstep();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            footstep();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            footstep();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            stopfootstep();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            stopfootstep();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            stopfootstep();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            stopfootstep();
        }
    }

    void footstep()
    {
        //footsteps.SetActive (true);
    }
    
    void stopfootstep()
    {
        footsteps.SetActive(false);
    }
}
