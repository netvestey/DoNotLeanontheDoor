using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class PickUpController : MonoBehaviour
{
    public Rigidbody rb;
    public MeshCollider coll;
    public VisualEffect fire2;
    public Transform Player, CollectiblesContainer, PlayerCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;
    public float DestroyTimer;
    private bool FireDestroyed = false;

    GameObject Candle;
    GameObject[] allCandles;

    public GameObject Timer;
    PauseMenu pauseMenu;

    [SerializeField] private AudioSource pickUpSound;
    [SerializeField] private AudioSource blowOutSound;
    [SerializeField] private AudioSource dropSound;

    private void Start()
    {
        fire2.SendEvent("Fire");

        //SetUp
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if(equipped)
        {
            rb.isKinematic = true;
            rb.useGravity = true;
            coll.isTrigger = true;
            slotFull = true;
            gameObject.GetComponent<CandleBob>().enabled = false;
        }

        pauseMenu = Timer.GetComponent<PauseMenu>();
    }

    private void Update()
    {
        if (pauseMenu.GameIsPaused == false)

        {
            if (equipped)
            {
                DestroyTimer += Time.deltaTime;
            }

            if (DestroyTimer > 7 && !FireDestroyed)
            {
                Blow();
            }
        }

        Vector3 distanceToPlayer = Player.position - transform.position;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pauseMenu.GameIsPaused == false)
            {
                allCandles = GameObject.FindGameObjectsWithTag("Candle");
                Candle = allCandles[0];
                float distanceToNearest = Vector3.Distance(Player.transform.position, Candle.transform.position);
                for (int i = 1; i < allCandles.Length; i++)
                {
                    float distanceToCurrent = Vector3.Distance(Player.transform.position, allCandles[i].transform.position);

                    if(distanceToCurrent < distanceToNearest) 
                    {
                        Candle = allCandles[i];
                        distanceToNearest = distanceToCurrent;
                    }
                }


                if (!equipped && distanceToPlayer.magnitude <= pickUpRange && !slotFull) PickUp();

                else if (equipped && slotFull && distanceToNearest > pickUpRange) Drop();

                else if (equipped && slotFull && distanceToNearest <= pickUpRange) Reignite();
            }
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make collectible a child of the camera and move it to default position
        transform.SetParent(PlayerCam);
        transform.localPosition = new Vector3(0.4f, -0.2f, 2f);
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        pickUpSound.Play();
        this.gameObject.tag = "PickedUpCandle";

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
        rb.useGravity = true;
    }   
    
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        dropSound.Play();
        this.gameObject.tag = "Candle";

        DestroyTimer = 0;

        //Set parent to null
        transform.SetParent(null);

        //Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;
        rb.useGravity = false;

        //Collectible carries momentum of player
        rb.velocity = Player.GetComponent<Rigidbody>().velocity;

        //AddForce
        rb.AddForce(PlayerCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(PlayerCam.up * dropUpwardForce, ForceMode.Impulse);

        //AddRandomRotation
        float random = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(random, random, random) * 10);
    }

    private void Blow()
    {
        FireDestroyed = true;
        blowOutSound.Play();
        fire2.Reinit();

    } 
    
    private void Reignite()
    {
        DestroyTimer = 0;
        fire2.SendEvent("Fire");
        fire2.enabled = true;
        FireDestroyed = false;

        pickUpSound.Play();
    }
}
