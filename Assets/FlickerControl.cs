using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;

    AudioSource flicker1;
    AudioSource flicker2;

    private void Start()
    {
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        flicker1 = allMyAudioSources[0];
        flicker2 = allMyAudioSources[1];
    }
    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }    
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;

        //int flicker = Random.Range(0, 10);
        //if(flicker == 0)
            //flicker1.Play();
        //else if(flicker == 5) 
            //flicker2.Play();

        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(1f, 3f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }    
}
