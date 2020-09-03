using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaButtonGenerator : MonoBehaviour
{
    [Header("キャラボタンのプレファブ")]
    public ChooseCharacter charaButtonPrefab;
    [Header("キャラボタンの生成位置")]
    public Transform charaTran;


    public void GenerateCharaButtons(int count)
    {
        for(int i =0;i<count;i++)
        {
            ChooseCharacter charaButton = Instantiate(charaButtonPrefab, charaTran, false);
            charaButton.SetUpCharaButton(i);
        }
    }
 
}
