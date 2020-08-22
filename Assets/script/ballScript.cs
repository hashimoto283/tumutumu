using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ballScript : MonoBehaviour
{
	public List<GameObject> ballList_yellow = new List<GameObject>();
	public List<GameObject> ballList_blue = new List<GameObject>();
	public List<GameObject> ballList_red = new List<GameObject>();
	public List<GameObject> ballList_green = new List<GameObject>();
	public List<GameObject> ballList_purple = new List<GameObject>();

	public GameObject ballPrefab;
	public Sprite[] ballSprites;
	private GameObject firstBall;
	private GameObject lastBall;
	private string currentName;
	List<GameObject> removableBallList = new List<GameObject>();
	public GameObject scoreGUI;
	private int point = 100;
	public GameObject exchangeButton;
	//********** 追記 **********//
	public bool isPlaying = true;
	//********** 追記 **********//
	private BallController ballController;

	void Start()
	{
		StartCoroutine(DropBall(50));
	}

	void Update()
	{
		//********** 追記 **********//
		if (isPlaying)
		{
			//********** 追記 **********//
			if (Input.GetMouseButtonDown(0) && firstBall == null)
			{
				OnDragStart();
			}
			else if (Input.GetMouseButtonUp(0))
			{
				OnDragEnd();
			}
			else if (firstBall != null)
			{
				OnDragging();
			}
			//********** 追記 **********//
		}
		//********** 追記 **********//
	}

	private void OnDragStart()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;
			string ballName = hitObj.name;
			if (ballName.StartsWith("Piyo"))
			{
				firstBall = hitObj;
				lastBall = hitObj;
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

			if (hitObj.name == currentName && lastBall != hitObj)
			{
				float distance = Vector2.Distance(hitObj.transform.position, lastBall.transform.position);
				if (distance < 1.0f)
				{
					lastBall = hitObj;
					PushToList(hitObj);
				}
			}
		}
	}

	private void OnDragEnd()
	{
		int remove_cnt = removableBallList.Count;
		if (remove_cnt >= 3)
		{
			for (int i = 0; i < remove_cnt; i++)
			{
				Destroy(removableBallList[i]);
			}
			scoreGUI.SendMessage("AddPoint", point * remove_cnt);
			StartCoroutine(DropBall(remove_cnt));
		}
		else
		{
			for (int i = 0; i < remove_cnt; i++)
			{
				ChangeColor(removableBallList[i], 1.0f);
			}
		}
		firstBall = null;
		lastBall = null;
	}

	IEnumerator DropBall(int count)
	{

		
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

	}
	public void ChangeColor()
    {

		//カラーナンバーが0だった場合カラーナンバー１にする（ボールリストナンバーイエローをボールリストナンバーブルーに変更）
		for (int i = 0; i < ballList_yellow.Count; i++)
        {
			ballList_yellow[i].GetComponent<SpriteRenderer>().sprite = ballSprites[1];
			ballList_blue.Add(ballList_yellow[i]);
			ballList_yellow.Remove(ballList_yellow[i]);
        }
		ballList_yellow.Clear();
			
    }
	IEnumerator RestrictPush()
	{
		exchangeButton.GetComponent<Button>().interactable = false;
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
		ballTexture.color = new Color(ballTexture.color.r, ballTexture.color.g, ballTexture.color.b, transparency);
	}
}