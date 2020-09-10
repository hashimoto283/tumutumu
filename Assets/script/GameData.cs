using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    //各スキルを列挙
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
        //各キャラの名前と番号とスキルを紐づけ
        public string name;
        public int charaNo;
        public int skillNo;
    }
    　　//Listで管理
        public List<CharaData> charaDataList = new List<CharaData>();
        [System.Serializable]
        public class SkillData
        {
           //スキルのナンバーとスキル内容と説明テキストを紐づけ
            public int skillNo;
            public SkillType skillType;
            public string description;
        }
    　　//Listで管理
        public List<SkillData> skillDataList = new List<SkillData>();
        public CharaButtonGenerator charaButtonGenerator;

        void Awake()
        {
    　　　　//各キャラと各スキルを全て生成
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
    }
}
