using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class ScoreScript : MonoBehaviour
{
	private int score = 0;
	public Stege2 stege2;
	public Stege3 stege3;
	public Stege4 stege4;
	void Start()
	{
		//初期スコア(0点)を表示
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
	//ballScriptからSendMessageで呼ばれるスコア加算用メソッド
	public void AddPoint(int point)
	{
		Debug.Log(point);       
		//各シーンを取得
		string sceneName = SceneManager.GetActiveScene().name;
		if(stege2)
        {
			stege2.Clearscene(score);
        }
		else if(stege3)
        {
			stege3.Clearscene(score);
        }
		else if(stege4)
        {
			stege4.Clearscene(score);
        }
		Debug.Log("st");

		score = score + point;
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
}