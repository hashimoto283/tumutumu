using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class ScoreScript : MonoBehaviour
{
	//スコアの値
	private int score = 0;
	//ステージを管理する
	public StageManager stageManager;
	//スコアのテキスト
	public Text scoreText;

	void Start()
	{
		//初期スコア(0点)を表示
		GetComponent<Text>().text = "Score: " + score.ToString();
	}
	/// <summary>
	/// スコアの加算処理
	/// </summary>
	/// <param name="point">ボールを消すときに増えるスコアの数</param>

	public void AddPoint(int point)
	{
		Debug.Log(point);
		Debug.Log("stege");
		score = score + point;
		scoreText.text = "Score : " + score.ToString();
		//各シーンを取得
		string sceneName = SceneManager.GetActiveScene().name;
		// クリアしているスコアに達したか判定
		stageManager.CheckClearStage(sceneName, score);
		
	}
}