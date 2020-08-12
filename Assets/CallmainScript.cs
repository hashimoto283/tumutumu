using UnityEngine;
using System.Collections;

public class CallmainScript : MonoBehaviour
{

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel("tumutumu");
		}
	}
}