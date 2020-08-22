using UnityEngine;
using System.Collections;
public class ExchangeScript : MonoBehaviour
{
	public ballScript BallScript; 
    void Start()
	{ 
		StartCoroutine(DropBall ());  
	}
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
	ballScript.ballList_yellow = new List<GameObject>();
        ballScript.ballList_blue = new List<GameObject>();
		ballScript.ballList_red = new List<GameObject>();
		ballScript.ballList_green = new List<GameObject>();
		ballScript.ballList_purple = new List<GameObject>();
	}
    IEnumerator DropBall()
	{
		BallScript.SendMessage("DropBall", 50);
		Debug.Log("s");
		yield return new WaitForSeconds(0.05f);
	}
}
