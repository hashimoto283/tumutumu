using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacter : MonoBehaviour
{
	[Header("キャラの所持スキル")]
	public GameData.SkillType charaSkillType;

	

 public	void OnClickChooseSkill()
	{

		GameData.instance.skilltype = charaSkillType;
		SceneManager.LoadScene("tumutumu");

		}
}