using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ScoreScript : MonoBehaviour
{
	private int score = 0;
	public Stege2 stege2; 
	void Start()
	{
		//初期スコア(0点)を表示
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
	//ballScriptからSendMessageで呼ばれるスコア加算用メソッド
	public void AddPoint(int point)
	{
		Debug.Log(point);        // <= 追記
		score = score + point;
		stege2.Clearscene(score);
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
}