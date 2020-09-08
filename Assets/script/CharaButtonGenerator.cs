using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaButtonGenerator : MonoBehaviour
{
    [Header("キャラボタンのプレファブ")]
    public ChooseCharacter charaButtonPrefab;
    [Header("キャラボタンの生成位置")]
    public Transform charaTran;

    /// <summary>
    /// 選択できるキャラを生成する処理
    /// </summary>
    /// <param name="count">キャラの個数</param>
    public void GenerateCharaButtons(int count)
    {
        //キャラを全部生成する処理
        for(int i =0;i<count;i++)
        {
            ChooseCharacter charaButton = Instantiate(charaButtonPrefab, charaTran, false);
            charaButton.SetUpCharaButton(i);
        }
    }
}
