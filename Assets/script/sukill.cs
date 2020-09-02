using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sukill : MonoBehaviour
{
   
    public float additionalTime;
    private TimeScript timeScript;
    private ballScript ballScript;

    public int SukillCount;
    private Button buttonskill;
    private void Start()
    {
        buttonskill = GetComponent<Button>();
        SetSkill();
    }
    private void SetSkill()
    {
        switch (GameData.instance.skilltype)
        {
            case GameData.SkillType.Timer:
                buttonskill.onClick.AddListener(Timer);
                break;
            case GameData.SkillType.ChangeColor:
                buttonskill.onClick.AddListener(ChangeColorSkill);
                break;
            case GameData.SkillType.DeleteBall:
                buttonskill.onClick.AddListener(DeleteBallSkill);
                break;
        }
    }
    public void Timer()
    {
        if (SukillCount > 0)
        {
            timeScript = GameObject.Find("Time").GetComponent<TimeScript>();





            timeScript.AddTime(additionalTime);
            Debug.Log("a");
            SukillCount--;
            buttonskill.interactable = false;
        }
    }
    public void ChangeColorSkill()
    {
        if (SukillCount > 0)
        {
            ballScript = GameObject.Find("Main Camera").GetComponent<ballScript>();
            ballScript.ChangeColor();
            Debug.Log("a");
            SukillCount--;
            buttonskill.interactable = false;
        }
    }
    public void DeleteBallSkill()
    {
        if (SukillCount > 0)
        {
            ballScript = GameObject.Find("Main Camera").GetComponent<ballScript>();
            ballScript.DeleteBall();
            SukillCount--;
            buttonskill.interactable = false;
        }

    }
}
