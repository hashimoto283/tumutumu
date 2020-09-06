using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ExchangeScript : MonoBehaviour
{
	public ballScript BallScript;

	public void Exchange()
	{
		//配列に「respawn」タグのついているオブジェクトを全て格納
		GameObject[] piyos = GameObject.FindGameObjectsWithTag("Respawn");
		//全て取り出し、削除
		foreach (GameObject obs in piyos)
		{ 
			Destroy(obs);
		}
	// ballScriptの持つリストを初期化(各リストに対して行う)
	    BallScript.ballList_yellow = new List<GameObject>();
        BallScript.ballList_blue = new List<GameObject>();
		BallScript.ballList_red = new List<GameObject>();
		BallScript.ballList_green = new List<GameObject>();
		BallScript.ballList_purple = new List<GameObject>();
		BallScript.removableBallList.Clear();
		StartCoroutine(BallScript.DropBall(50));
	}
}
