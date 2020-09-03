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
            {
				charaImage.sprite = Resources.Load<Sprite>("chara_" + charaData.charaNo);
				foreach(GameData.SkillData skillData in GameData.instance.skillDataList)
                {
					if(skillData.skillNo == charaData.skillNo)
                    {
						charaSkillType = skillData.skillType;
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

		GameData.instance.skilltype = charaSkillType;
		SceneManager.LoadScene("tumutumu");

		}
}