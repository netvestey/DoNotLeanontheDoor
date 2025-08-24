using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource annOne;
    [SerializeField] private AudioSource owner;
    [SerializeField] private AudioSource polite;
    [SerializeField] private AudioSource beshozny;
    [SerializeField] private AudioSource becomecandle;
    [SerializeField] private AudioSource attention1;
    [SerializeField] private AudioSource attention2;

    public GameObject Timer;
    metroTimer MetroTimer;

    private bool ownerPlayed = false;
    private bool politePlayed = false;
    private bool beshoznyPlayed = false;
    private bool becomecandlePlayed = false;
    private bool attentionPlayed = false;

    void Start()
    {
        annOne.Play();
        MetroTimer = Timer.GetComponent<metroTimer>();
    }

    void Update()

    {
        if (MetroTimer.timeValue < 270 && MetroTimer.timeValue > 260 && ownerPlayed == false)
        {
            owner.Play();
            ownerPlayed = true;
        }
        else if (MetroTimer.timeValue < 240 && MetroTimer.timeValue > 230 && politePlayed == false)
        {
            polite.Play();
            politePlayed = true;
        }
        else if (MetroTimer.timeValue < 200 && MetroTimer.timeValue > 180 && beshoznyPlayed == false)
        {
            beshozny.Play();
            beshoznyPlayed = true;
        }
        else if (MetroTimer.timeValue < 130 && MetroTimer.timeValue > 100 && becomecandlePlayed == false)
        {
            becomecandle.Play();
            becomecandlePlayed = true;
        }
        else if (MetroTimer.timeValue < 65 && MetroTimer.timeValue > 55 && attentionPlayed == false)
        {
            int flicker = Random.Range(0, 2);
            if(flicker >= 1)
            attention1.Play();
            else if(flicker < 1) 
            attention2.Play();

            attentionPlayed = true;
        }
    }
}

