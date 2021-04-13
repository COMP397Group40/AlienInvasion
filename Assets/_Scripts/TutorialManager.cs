using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public static bool pauseClicked = false;
    public static bool mapClicked = false;
    public static bool jumpClicked = false;
    public Button pauseButton;
    public Button mapButton;
    public Button jumpButton;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(pauseOnClick);
        mapButton.onClick.AddListener(mapOnClick);
        jumpButton.onClick.AddListener(jumpOnClick);
    }
    void pauseOnClick()
    {
        pauseClicked = true;
    }
    void mapOnClick()
    {
        mapClicked = true;
    }
    void jumpOnClick()
    {
        jumpClicked = true;
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if( i == popUpIndex)
            {
                popUps[i].SetActive(true);
            } else
            {
                popUps[i].SetActive(false);
            }
        }
        if(popUpIndex == 0)
        {
            if(jumpClicked == true)
            {
                popUpIndex++;
            } 
            
        } else if (popUpIndex == 1)
        {
            if (mapClicked == true)
            {
                popUpIndex++;
            }
        } else if (popUpIndex == 2)
        {
            if (pauseClicked == true)
            {
                popUpIndex++;
            }
        }
    }
}
