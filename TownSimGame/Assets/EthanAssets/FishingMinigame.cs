using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingMinigame : MonoBehaviour {

    public float MaxTimer;
    public float TimeLeft;
    public int FishLevel;
    public int KeycodeRandom;
    public bool KeycodeRandomBool = false;
    public KeyCode Objective;
    public bool Fishing = false;
    public bool FishingMinigameStart = false;
    GameObject Player;
    public Text Hooked;
    public Text FishingButtonUI;
    public Text TimerText;
    public Text Success;
    public Text Fails;
    public Text FishCount;

    public int TinyFish;
    public int SmallFish;
    public int Fish;
    public int BigFish;
    public int HugeFish;

    public int Score = 0;
    public int FailScore = 0;

    public Rigidbody PlayerRigid;


	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Playar");
        PlayerRigid = this.gameObject.GetComponent<Rigidbody>();
        FishCount.text = "Tiny fish: " + TinyFish + "   " + "Small fish: " + SmallFish + "   " + "Medium fish: " + Fish + "   " + "Big fish: " + BigFish + "   " + "Huge fish: " + HugeFish;
    }
	
	// Update is called once per frame
	void Update ()
    {
        TimerText.text = TimeLeft.ToString("F");

        if (FishingMinigameStart == true)
        {
            if (KeycodeRandomBool == true)
            {
                Invoke("KeycodeRandomiser", 0f);
            }

            if (TimeLeft >= 0)
            {
                TimeLeft -= Time.deltaTime;
            }

            if (TimeLeft <= 0)
            {
                KeycodeRandomBool = true;
                FailScore += 1;
                Fails.text = "Fails: " + FailScore;
                TimeLeft = MaxTimer;
            }

            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(Objective) == true)
                {
                    KeycodeRandomBool = true;
                    Score += 1;
                    TimeLeft = MaxTimer;
                    Success.text = "Score: " + Score;
                }
                if (Input.GetKeyDown(Objective) == false)
                {
                    KeycodeRandomBool = true;
                    FailScore += 1;
                    TimeLeft = MaxTimer;
                    Fails.text = "Fails: " + FailScore;
                }
            }

            if (Score == 8)
            {
                Score = 0;
                FailScore = 0;

                switch (FishLevel)
                {
                    case 1:
                        TinyFish += 1;
                        break;
                    case 2:
                        SmallFish += 1;
                        break;
                    case 3:
                        Fish += 1;
                        break;
                    case 4:
                        BigFish += 1;
                        break;
                    case 5:
                        HugeFish += 1;
                        break;
                    default:
                        Debug.Log("We're gonna need a bigger boat...");
                        break;
                }
                FishCount.text = "Tiny fish: " + TinyFish + "   " + "Small fish: " + SmallFish + "   " + "Medium fish: " + Fish + "   " + "Big fish: " + BigFish + "   " + "Huge fish: " + HugeFish;
                Invoke("FishingMinigameEnd", 0f);       
            }

            if (FailScore == 3)
            {
                Score = 0;
                FailScore = 0;
                Invoke("FishingMinigameEnd", 0f);
            }
        }
	}

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "FishingSpot" && Input.GetKeyDown(KeyCode.E) && Fishing == false)
        {
            Fishing = true;
            Player.gameObject.GetComponent<PlayerControls>().speed = 0;
            Player.gameObject.GetComponent<PlayerControls>().rotspeed = 0;
            PlayerRigid.velocity = new Vector3 (0f,0f,0f);
            PlayerRigid.angularVelocity = new Vector3(0, 0, 0);
            Invoke("HookTimer", Random.Range(3f, 8f));
        }
    }

    void HookTimer()
    {
        Hooked.enabled = true;
        FishLevel = Random.Range(1, 6);
        MaxTimer = ((5f / FishLevel) + 0.5f);
        TimeLeft = MaxTimer;
        Debug.Log(FishLevel + " " + MaxTimer + " " + TimeLeft);
        Invoke("FishingMiniGameUI", 3f);
    }

    void FishingMiniGameUI()
    {
        KeycodeRandomBool = true;
        Hooked.enabled = false;
        FishingButtonUI.enabled = true;
        TimerText.enabled = true;
        Success.enabled = true;
        Fails.enabled = true;
        Success.text = "Score: " + Score;
        Fails.text = "Fails: " + FailScore;

        FishingMinigameStart = true;
    }

    void FishingMinigameEnd()
    {
        KeycodeRandomBool = false;
        Fishing = false;
        FishingMinigameStart = false;
        FishingButtonUI.enabled = false;
        TimerText.enabled = false;
        Success.enabled = false;
        Fails.enabled = false;
        Player.gameObject.GetComponent<PlayerControls>().speed = 4;
        Player.gameObject.GetComponent<PlayerControls>().rotspeed = 80;
    }

    void KeycodeRandomiser()
    {
        KeycodeRandom = Random.Range(0, 4);

        if (KeycodeRandom == 1)
        {
            Objective = KeyCode.W;
            FishingButtonUI.text = "W";
        }

        if (KeycodeRandom == 2)
        {
            Objective = KeyCode.A;
            FishingButtonUI.text = "A";
        }

        if (KeycodeRandom == 3)
        {
            Objective = KeyCode.S;
            FishingButtonUI.text = "S";
        }

        if (KeycodeRandom == 0)
        {
            Objective = KeyCode.D;
            FishingButtonUI.text = "D";
        }

        KeycodeRandomBool = false;
    }
}
