using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Time_text;

    [SerializeField] private float trick_Timer;
    private static bool WinCheck;
    private static bool LoseCheck;
    void Start()
    {
        WinCheck = false;
        LoseCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        trick_Timer = trick_Timer - Time.deltaTime;
        Time_text.text = "" + Mathf.Floor(trick_Timer);

        if (trick_Timer <= 0 && !WinCheck && !LoseCheck)
        {
            Lose_Level();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !WinCheck && !LoseCheck)
        {
            Win_Level();
        }
            
    }

    public static void Lose_Level()
    {
        LoseCheck = true;
        SceneManager_Script.Load_PopUP_Scene("Lose");
    }

    public static void Win_Level()
    {
        WinCheck = true;
        SceneManager_Script.Load_PopUP_Scene("Win");
    }
}
