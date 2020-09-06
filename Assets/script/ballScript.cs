using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ballScript : MonoBehaviour
{
	public List<GameObject> ballList_yellow = new List<GameObject>();
	public List<GameObject> ballList_blue = new List<GameObject>();
	public List<GameObject> ballList_red = new List<GameObject>();
	public List<GameObject> ballList_green = new List<GameObject>();
	public List<GameObject> ballList_purple = new List<GameObject>();
	public int remove_cnt;
	public GameObject ballPrefab;
	public Sprite[] ballSprites;
	private GameObject firstBall;
	private GameObject lastBall;
	private string currentName;
	public List<GameObject> removableBallList = new List<GameObject>();
	public GameObject scoreGUI;
	private int point = 100;
	public GameObject exchangeButton;
	public bool isPlaying = true;
	private BallController ballController;
	private bool isDraging=true;

	void Start()
	{
		//始めにボールを50個生成
		StartCoroutine(DropBall(50));
	}

	void Update()
	{
		if (isPlaying&&isDraging)
		{
			if (Input.GetMouseButtonDown(0) && firstBall == null)
			{
				OnDragStart();;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				OnDragEnd();
			}
			else if (firstBall != null)
			{
				OnDragging();
			}
		}
	}

	public void OnDragStart()
	{
		//RayCastHit2Dでクリックしたボールの位置情報を取得
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;
			string ballName = hitObj.name;
			//ボールの名前がPiyoかどうか判別
			if (ballName.StartsWith("Piyo"))
			{
				firstBall = hitObj;
				lastBall = hitObj;
				//currentNameにドラッグしたボールを格納
				currentName = hitObj.name;
				removableBallList = new List<GameObject>();
				PushToList(hitObj);
			}
		}
	}

	private void OnDragging()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;
			//取得したオブジェクトとcurrentNameが同じで最後のボールが別のオブジェクトの場合
			if (hitObj.name == currentName && lastBall != hitObj)
			{　　
				//hitballとlastballの距離を測る
				float distance = Vector2.Distance(hitObj.transform.position, lastBall.transform.position);
				if (distance < 1.0f)
				{
					lastBall = hitObj;
					PushToList(hitObj);
				}
			}
		}
	}

	public void OnDragEnd()
	{
		//ドラッグしたボールが3個以上なら削除
		int remove_cnt = removableBallList.Count;
		if (remove_cnt >= 3)
		{
			Debug.Log(remove_cnt);
			//消したボールを各色のボールリストに格納
			GameObject removableobj = removableBallList[0];
			if (ballList_yellow.Count > 0 && ballList_yellow[0].name.StartsWith(removableobj.name))
			{
				Debug.Log("yellow");
				for (int i = 0; i < remove_cnt; i++)
				{
					ballList_yellow.Remove(removableBallList[i]);
					Destroy(removableBallList[i]);
				}
			}
			else if (ballList_blue.Count > 0 && ballList_blue[0].name.StartsWith(removableobj.name))
			{
				Debug.Log("blue");
				for (int i = 0; i < remove_cnt; i++)
				{
					ballList_blue.Remove(removableBallList[i]);
					Destroy(removableBallList[i]);

				}
			}
			else if (ballList_red.Count > 0 && ballList_red[0].name.StartsWith(removableobj.name))
			{
				Debug.Log("red");
				for (int i = 0; i < remove_cnt; i++)
				{
					ballList_red.Remove(removableBallList[i]);
					Destroy(removableBallList[i]);
				}
			}
			else if (ballList_green.Count > 0 && ballList_green[0].name.StartsWith(removableobj.name))
			{
				Debug.Log("green");
				for (int i = 0; i < remove_cnt; i++)
				{
					ballList_green.Remove(removableBallList[i]);
					Destroy(removableBallList[i]);
				}
			}
			else if (ballList_purple.Count > 0 && ballList_purple[0].name.StartsWith(removableobj.name))
			{
				Debug.Log("purple");
				for (int i = 0; i < remove_cnt; i++)
				{
					ballList_purple.Remove(removableBallList[i]);
					Destroy(removableBallList[i]);
				}
			}
	        removableBallList = new List<GameObject>();
			scoreGUI.SendMessage("AddPoint", point * remove_cnt);
			StartCoroutine(DropBall(remove_cnt));
		}
		else
		{
			Debug.Log(remove_cnt);
			//消したボールのListの初期化
			for (int i = 0; i < remove_cnt; i++)
			{
				ChangeColor(removableBallList[i], 1.0f);
			}
		}
		//ChangeColorを使ってもDragされてない状態にする
		firstBall = null;
		lastBall = null;
	}

	public IEnumerator DropBall(int count)
	{
		isDraging = false;
		//countが50の場合のみRestrictPushを呼び出す
		if (count == 50)
		{
			StartCoroutine("RestrictPush");
		}
		for (int i = 0; i < count; i++)
		{
			Vector2 pos = new Vector2(Random.Range(-2.0f, 2.0f), 7f);
			//ボールプレファブを生成する　プレファブの生成角度をRandom.Rangeで決める
			GameObject ball = Instantiate(ballPrefab, pos,
			Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
			//ボールの種類をランダムに決める
			int spriteId = Random.Range(0, 5);
			//生成するボールの名前をPiyo0~4に決めている
			ball.name = "Piyo" + spriteId;
			//SpriteRenderer型のspriteObj変数を宣言して、ballObjectの持っているSpriteRendererを代入
			SpriteRenderer spriteObj = ball.GetComponent<SpriteRenderer>();
			//配列でボールの絵を5種類のPiyoに差し替える
			spriteObj.sprite = ballSprites[spriteId];
			//リストでball変数で管理
			if (spriteId == 0)
			{
				ballList_yellow.Add(ball);
			}
			else if (spriteId == 1)
			{
				ballList_blue.Add(ball);

			}
			else if (spriteId == 2)
			{
				ballList_red.Add(ball);

			}
			else if (spriteId == 3)
			{
				ballList_green.Add(ball);

			}
			else if (spriteId == 4)
			{
				ballList_purple.Add(ball);
			}
			//0.05秒停止する処理
			yield return new WaitForSeconds(0.05f);
		}
		isDraging = true;
	}

	public void ChangeColor()
	{
		//ボールリストナンバーイエローをボールリストナンバーブルーに変更
		for (int i = 0; i < ballList_yellow.Count; i++)
		{
			ballList_yellow[i].GetComponent<SpriteRenderer>().sprite = ballSprites[1];
			ballList_yellow[i].name = "Piyo" + 1;
			ballList_blue.Add(ballList_yellow[i]);
			Debug.Log(ballList_yellow.Count);
		}
		ballList_yellow.Clear();
	}

	IEnumerator RestrictPush()
	{
		exchangeButton.GetComponent<Button>().interactable = false;
		//exchangeは5秒のインターバルがあるようにする
		yield return new WaitForSeconds(5.0f);
		exchangeButton.GetComponent<Button>().interactable = true;
	}

	void PushToList(GameObject obj)
	{
		removableBallList.Add(obj);
		ChangeColor(obj, 0.5f);
	}

	void ChangeColor(GameObject obj, float transparency)
	{
		SpriteRenderer ballTexture = obj.GetComponent<SpriteRenderer>();
		ballTexture.color = new Color(ballTexture.color.r, ballTexture.color.g, ballTexture.color.b, transparency);;
	}

	public void DeleteBall()
	{
		//各ボールを配列で管理
		int[] array = new int[5];
		array[0] = ballList_yellow.Count;
		array[1] = ballList_blue.Count;
		array[2] = ballList_red.Count;
		array[3] = ballList_green.Count;
		array[4] = ballList_purple.Count;
		//数が多い配列を比べて選ぶ処理
		int maxNum = array[0];
		int index = 0;
		for (int i = 1; i < array.Length; i++)
		{
			if (maxNum < array[i])
			{
				maxNum = array[i];
				index = i;
			}
		}
		Debug.Log(maxNum);
		Debug.Log(index);
		if (index == 0)
		{
			for (int i = 0; i < ballList_yellow.Count; i++)
            {
				Destroy(ballList_yellow[i]);
			}
			ballList_yellow.Clear();
		}
		else if (index == 1)
		{
			for (int i = 0; i < ballList_blue.Count; i++)
			{
				Destroy(ballList_blue[i]);
			}
			ballList_blue.Clear();
		}
		else if (index == 2)
        {
			for (int i = 0; i < ballList_red.Count; i++)
			{
				Destroy(ballList_red[i]);
			}
			ballList_red.Clear();
		}
		else if (index == 3)
        {
			for (int i = 0; i < ballList_green.Count; i++)
			{
				Destroy(ballList_green[i]);
			}
			ballList_green.Clear();
		}
		else if (index == 4)
        {
			for (int i = 0; i < ballList_purple.Count; i++)
			{
				Destroy(ballList_purple[i]);
			}
			ballList_purple.Clear();
		}
		//消した個数を新しくボールを落とす
		StartCoroutine(DropBall(maxNum));
	scoreGUI.SendMessage("AddPoint", point * maxNum);
	}
}