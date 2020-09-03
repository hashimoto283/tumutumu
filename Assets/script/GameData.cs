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

    [System.Serializable]
    public class CharaData
    {
        public string name;
        public int charaNo;
        public int skillNo;
    }
        public List<CharaData> charaDataList = new List<CharaData>();
        [System.Serializable]
        public class SkillData
        {
            public int skillNo;
            public SkillType skillType;
            public string description;
        }
        public List<SkillData> skillDataList = new List<SkillData>();
        public CharaButtonGenerator charaButtonGenerator;

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
        //キャラボタンの生成
        
             charaButtonGenerator.GenerateCharaButtons(charaDataList.Count);
        Debug.Log("a");
    }
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
    
}
