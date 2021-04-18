using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchievements : MonoBehaviour
{
    public GameObject achNote;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achImage;
    public GameObject achTitle;
    public GameObject achDesc;
    public GameObject quest;
    public static int achCount = 0;
    public int ach01Code;
    public int ach02Code;
    public int ach03Code;


    // Update is called once per frame
    void Update()
    {
        if (achCount == 5 && ach01Code != 1234)
        {
            StartCoroutine(Trigger01Ach());
        }
        if (achCount == 10 && ach02Code != 1234)
        {
            StartCoroutine(Trigger02Ach());
        }
        if (achCount == 15 && ach03Code != 1234)
        {
            StartCoroutine(Trigger03Ach());
        }
    }

    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 1234;
        achSound.Play();
        achImage.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement Unlocked";
        achDesc.GetComponent<Text>().text = "Killed 5 Zombies";
        quest.GetComponent<Text>().text = "Kill 10 Zombies";
        achNote.SetActive(true);
        yield return new WaitForSeconds(3);
        //reset UI
        achImage.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
        achNote.SetActive(false);
    }

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Code = 1234;
        achSound.Play();
        achImage.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement Unlocked";
        achDesc.GetComponent<Text>().text = "Killed 10 Zombies";
        quest.GetComponent<Text>().text = "Kill 15 Zombies";
        achNote.SetActive(true);
        yield return new WaitForSeconds(3);
        //reset UI
        achImage.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
        achNote.SetActive(false);
    }

    IEnumerator Trigger03Ach()
    {
        achActive = true;
        ach03Code = 1234;
        achSound.Play();
        achImage.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement Unlocked";
        achDesc.GetComponent<Text>().text = "Killed 15 Zombies";
        quest.GetComponent<Text>().text = "Escape the Horde";
        achNote.SetActive(true);
        yield return new WaitForSeconds(3);
        //reset UI
        achImage.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
        achNote.SetActive(false);
    }
}
