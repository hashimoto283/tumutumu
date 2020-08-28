using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDate : MonoBehaviour
{
    public static GameDate instance;
    public enum SkillType
    {
        Timer,
        ChangeColor,
        DeleteBall,

    }
    public SkillType skilltype;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
   
}
