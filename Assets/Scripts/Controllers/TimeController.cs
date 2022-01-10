using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    // Instance
    static TimeController instance;

    // Accessible Text
    [SerializeField]
    GameObject timeDisplay;
    TMP_Text timeDisplayText;

    // Timer Components
    public float time_scale;

    public float seconds;
    public float minutes;
    public float hours;
    public float days;

    public int totalHourCounter;    // Counts the total hours to increment the Day

    // Time-in-General
    string AM = "AM";
    string PM = "PM";

    string dayName;     // Name of the Day (i.e. Monday, Tuesday, etc.)
    bool dayNight;      // Toggles Day and Night Cycle
    static bool timeflow;      // Toggles flow of time if running or paused.
    
    private void Awake() {
        CreateInstance();
    }

    void Start()
    {
        
    }


    void Update()
    {
        // If true: time flows, false: time is paused.
        if (timeflow)
            Increment();
    }

    void FixedUpdate()
    {

    }

    void CreateInstance()
    {
        if (instance != null)
        {
            Debug.Log("Destroy Time Controller");
            Destroy(this.gameObject);
            return;
        }
        else
        {   
            // Debug.Log("Null: Initializing Now!");
            Initialization();
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        timeDisplayText = timeDisplay.GetComponent<TMP_Text>();
    }

    public static TimeController GetInstance()
    {
        return instance;
    }

    void OnDestroy()
    {
        // Debug.Log("Destroy Time Controller");
    }

    void Initialization()
    {
        timeflow = true;
        dayNight = true;
        seconds += Time.deltaTime;
        minutes = 0;
        hours = 6;                              // Day starts at 6 AM
        days = 1;                               // Starts at Day 1
        totalHourCounter = ((int)hours);


    }

    void Increment()
    {
        seconds = seconds + (Time.deltaTime * time_scale);

        if (seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        }

        if (minutes >= 60)
        {
            hours += 1;
            totalHourCounter += 1;
            minutes = 0;
        }

        if (hours == 12 && minutes == 0 && seconds == 0)
        {
            ToggleDayNight();
        }

        if (hours > 12)
            hours = 1;      // Sets to 1 after 12;


        if (totalHourCounter % 24 == 0 && minutes == 0 && seconds == 0)
        {
            days += 1;
            totalHourCounter = 0;
        }


        if (minutes % 10 == 0)
            DisplayTime();

    }

    void ToggleDayNight()
    {
        // Day = True; Night = False
        if (dayNight)    // if Day, set to Night
            dayNight = false;
        else            // if Night, set to Day
            dayNight = true;
    }

    void DisplayTime()
    {

        int d = ((int)days);
        int h = ((int)hours);
        int m = ((int)minutes);
        int s = ((int)seconds);

        string d_text = (d > 9) ? d.ToString("00") : d.ToString("0");

        string partOfDay = (dayNight) ? AM : PM;

        string ttext = "Day " + d_text + " " + h.ToString("00") + ":" + m.ToString("00") + " " + partOfDay; // + ":" + s.ToString("00");


        timeDisplayText.text = ttext;
    }

    public void ToggleTimeFlow()
    {
        if (timeflow)
        {
            // Debug.Log("Time Stops");
            timeflow = false;
        }
        else
        {
            // Debug.Log("Time Flows");
            timeflow = true;
        }

    }

    public bool IsTimeFlow()
    {
        return timeflow;
    }



    
}
