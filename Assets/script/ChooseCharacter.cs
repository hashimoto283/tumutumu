using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
	[Header("キャラの所持スキル")]
	public GameData.SkillType charaSkillType;
	[Header("キャラのイメージ")]
	public Image charaImage;
	[Header("キャラの説明表示")]
	public Text skillDescription;
	public void SetUpCharaButton(int no)
    {
		foreach(GameData.CharaData charaData in GameData.instance.charaDataList)
        {
			if(charaData.charaNo ==no)
            {　//キャラの画像設定
				charaImage.sprite = Resources.Load<Sprite>("chara_" + charaData.charaNo);
				foreach(GameData.SkillData skillData in GameData.instance.skillDataList)
                {　　//スキルとキャラを合わせる
					if(skillData.skillNo == charaData.skillNo)
                    {
						charaSkillType = skillData.skillType;
						//スキル説明
						skillDescription.text = skillData.description;
						break;
                    }
                }
				break;
            }
        }
    }
	

 public	void OnClickChooseSkill()
	{
		//キャラを選択後にゲームシーンに飛ぶ
		GameData.instance.skilltype = charaSkillType;
		SceneManager.LoadScene("tumutumu");

		}
}