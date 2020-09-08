using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StageManager : MonoBehaviour
{
    // enumを作成し、シーンの名前を列挙子に登録
    public enum SceneName
    {
        tumutumu,
        Stege2,
        Stege3,
        title
    }
    public SceneName nextSceneName;
    private bool gameClear = false;
    public Text Clear;

    /// <summary>
    /// ステージクリアの得点に達しているか判定
    /// </summary>
    /// <param name="sceneName">現在のシーンの名前</param>
    /// <param name="score">判定するスコアの値</param>
    public void CheckClearStage(string sceneName, int score)
    {
        Debug.Log(sceneName);
        Debug.Log(score);
        // 現在のシーンの名前を引数で渡して、ステージクリアに必要なスコアをステージごとに設定
        int stageClearScore = GetStageClearScore(sceneName);
        // 判定
        if (score >= stageClearScore)
        {
            Debug.Log("stege clear");
            gameClear = true;
            Clear.enabled = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// シーンの名前を使ってそのシーンをクリアするための判定値を戻す
    /// </summary>
    /// <param name="sceneName">現在のシーンの名前</param>
    /// <returns></returns>
    private int GetStageClearScore(string sceneName)
    {
        int value = 0;
        // 文字列をenumに変換して分岐にかける(文字列による直接入力は、打ち間違える可能性があるため避ける)
        SceneName checkSceneName = (SceneName)Enum.Parse(typeof(SceneName), sceneName, true);
        // 現在のステージによって分岐
        switch (checkSceneName)
        {
            case SceneName.tumutumu:
                value = 3000;
                break;
            case SceneName.Stege2:
                value = 5000;
                break;
            case SceneName.Stege3:
                value = 10000;
                break;
        }
        // 取得した点数を戻す
        return value;
    }
    
    public void Update()
    {
        if (gameClear == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //登録しているシーンへ遷移
                SceneManager.LoadScene(nextSceneName.ToString());
                Time.timeScale = 1.0f;
            }
        }
    }
}