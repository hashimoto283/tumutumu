using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stege3 : MonoBehaviour
{
    private bool gameClear = false;
    public Text Clear;
    private ScoreScript ScoreScript;
 
   public void Clearscene(int score)
    {
        Debug.Log(score);
        ScoreScript = GameObject.Find("Score").GetComponent< ScoreScript > ();
        if (score>=5000)
        {
            Debug.Log("s");
            gameClear = true;
            Clear.enabled = true;
            Time.timeScale = 0;
        }
    }

    public void Update()
    {
        if (gameClear == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Stege3");
                Time.timeScale = 1.0f;
            }
        }
    }
}
