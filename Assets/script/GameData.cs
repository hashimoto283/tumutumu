using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public enum SkillType
    {
        Timer,
        ChangeColor,
        DeleteBall,

    }
    public SkillType skilltype;

    public class CharaData
    {
        public string name;
        public int no1;
        public GameData.SkillType skillType;
    }
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
