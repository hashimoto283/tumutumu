using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MyGameManagerData : MonoBehaviour
{
    public string nextSceneName;
    public GameObject character;
    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "SelectCharacterTitle")
        {
            nextSceneName = "";
            character = null;

        }
    }
    public void SetNextSceneName(string nextSceneName)
    {
        this.nextSceneName = nextSceneName;
    }
    public string GetNextSceneName()
    {
        return nextSceneName;
    }
    public void SetCharacter(GameObject character)
    {
        this.character = character;
    }
    public GameObject GetCharacter()
    {
        return character;
    }
}
