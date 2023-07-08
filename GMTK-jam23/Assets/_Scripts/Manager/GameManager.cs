using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{

    public int Phase { get; private set; }
    // Use this for initialization

    public void ChangePhase()
    {
        Phase += 1;
    }

    public void ChangeToLastScene()
    {
        
    }
    public void EndScene()
    {

    }
    void LoadScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }

    void LoadScene(int[] _scenes)
    {
        SceneManager.LoadScene(_scenes[0]);
        for (int i = 1; i < _scenes.Length; i++)
        {
            SceneManager.LoadSceneAsync(_scenes[i], LoadSceneMode.Additive);
        }
    }
}
