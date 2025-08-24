using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DisappearObjects : MonoBehaviour
{
    GameObject Passenger;
    public GameObject CollectibleToSpawn;
    public VisualEffect Fire2;
    GameObject[] victim;
    float timePassed = 0f;
    public GameObject Timer;
    PauseMenu pauseMenu;
    public GameObject Plane1;

    [SerializeField] private AudioSource disappearSound;

    void Start()
    {
        Passenger = FindRandomPassenger();
        pauseMenu = Timer.GetComponent<PauseMenu>();

        Plane1.SetActive(false);

    }

    void Update()
    {
        if (pauseMenu.GameIsPaused == false)
        { timePassed += Time.deltaTime; }
        if (FindRandomPassenger() != null)
        {
            if (timePassed > 12f)
            { DisappearAlgo(); }
        }
        else
        { TurnEye(); }
    }

    GameObject FindRandomPassenger()
    {
        InsidePassenger();
        if (victim.Length > 0)
        {
            int rand = Random.Range(0, victim.Length);
            if (!IsVisibleOnScreen(victim[rand]))
            {
                return victim[rand];
            }
            else
            { 
                int randtwo = Random.Range(0, victim.Length);
                return victim[randtwo];
            }
        }
        else 
        { 
            return null; 
        }
    }

    void InsidePassenger()
    {
        victim = GameObject.FindGameObjectsWithTag("Passenger");
    }    

    private bool IsVisibleOnScreen(GameObject target)
    {
        Camera PlayerCam = Camera.main;
        Vector3 targetScreenPoint = PlayerCam.WorldToScreenPoint(target.GetComponent<Renderer>().bounds.center);

        if ((targetScreenPoint.x < 0) ||  (targetScreenPoint.x > Screen.width) || 
            (targetScreenPoint.y <0) || (targetScreenPoint.y > Screen.height))
        {
            return false;
        }

        if (targetScreenPoint.z < 0)
        {
            return false;
        }

        return true;
    }

    void DisappearAlgo()
    {
        Passenger = FindRandomPassenger();
        if (!IsVisibleOnScreen(Passenger))
        {
            Instantiate(CollectibleToSpawn, Passenger.transform.position, Quaternion.identity);
            Destroy(Passenger);
            disappearSound.Play();
            timePassed = 0f;
        }
    }

    void TurnEye()
    {
        Plane1.SetActive(true);
    }
}
