using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sukill : MonoBehaviour
{
    //追加する制限時間の秒数
    public float additionalTime;
    public TimeScript timeScript;
    private ballScript ballScript;
    //スキルの使用回数
    public int SukillCount;
    //ボタンを押すとスキルが発動する処理
    private Button buttonskill;

    private void Start()
    {
        buttonskill = GetComponent<Button>();
        SetSkill();
    }

    /// <summary>
    /// スキルの個数設定
    /// </summary>
    private void SetSkill()
    {
        switch (GameData.instance.skilltype)
        {
            //スキルボタンを押した時に適切なスキルを入れるためにAddListenerで処理を書く
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

    /// <summary>
    /// 制限時間を増やすスキル処理
    /// </summary>
    public void Timer()
    {
        TrigggerSkill();
        timeScript.AddTime(additionalTime);

    }

    /// <summary>
    /// ボールの色を変更するスキル処理
    /// </summary>
    public void ChangeColorSkill()
    {
        TrigggerSkill();
        ballScript.ChangeColor();
    }
    /// <summary>
    /// 一番多いボールを消すスキル処理
    /// </summary>

    public void DeleteBallSkill()
    {
        TrigggerSkill();
        ballScript.DeleteBall();
    }

    /// <summary>
    /// スキルの使用回数を決める処理
    /// </summary>
    private void TrigggerSkill()
    {
        // スキルの使用回数確認
        if (SukillCount > 0)
        {
            ballScript = GameObject.Find("Main Camera").GetComponent<ballScript>();
            SukillCount--;
            buttonskill.interactable = false;
        }
    }

}
