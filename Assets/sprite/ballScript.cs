﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ballScript : MonoBehaviour
{

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
			GameObject ball = Instantiate(ballPrefab, pos,
				Quaternion.AngleAxis(Random.Range(-40, 40), Vector3.forward)) as GameObject;
			int spriteId = Random.Range(0, 5);
			ball.name = "Piyo" + spriteId;
			SpriteRenderer spriteObj = ball.GetComponent<SpriteRenderer>();
			spriteObj.sprite = ballSprites[spriteId];
			yield return new WaitForSeconds(0.05f);
		}
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