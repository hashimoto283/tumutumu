using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
	private float time = 60;
	public ballScript BallScript;
	public GameObject exchangeButton;
	public GameObject gameOverText;
	public GameObject sukiruButton;
	public Text timeText;

	void Start()
	{
	//ゲームオーバー時のテキストを消す
		gameOverText.SetActive(false);
		timeText = GetComponent<Text>();
		//テキストに時間を表示する
		timeText.text = ((int)time).ToString();
	}

     public void Update()
	{
		//制限時間を減らす
		time -= Time.deltaTime;
		if (time < 0)
		{
			StartCoroutine("GameOver");
		}
		if (time < 0) time = 0;
		//時間が0になるまで制限時間を表示
		 timeText.text = ((int)time).ToString();
	}

	/// <summary>
	/// ゲームオーバー時の処理
	/// </summary>
	IEnumerator GameOver()
	{
		gameOverText.SetActive(true);
		//exchange使用不可
		exchangeButton.GetComponent<Button>().interactable = false;
		//消せないようにする
		BallScript.isPlaying = false;
		yield return new WaitForSeconds(2.0f);
		if (Input.GetMouseButtonDown(0))
		{
			string sceneName = SceneManager.GetActiveScene().name;
			SceneManager.LoadScene(sceneName);
			Debug.Log("continue scene");
		}
	}

	/// <summary>
	/// 制限時間を追加する処理
	/// </summary>
	/// <param name="amountTime">追加する時間の秒数</param>
	public void AddTime(float amountTime)
	{
		Debug.Log(amountTime);
		time += amountTime;
		Debug.Log(time);
	}
}