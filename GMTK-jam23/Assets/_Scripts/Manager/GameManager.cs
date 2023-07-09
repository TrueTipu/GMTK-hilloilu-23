using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public PostProcessVolume PPObjectReference { get; private set; }

    [SerializeField] Phase phase;
    public int Phase => phase.phase;

    [SerializeField] int nextScene;
    // Use this for initialization

    bool monsterActive;
    public bool MonsterActive
    {
        get
        {
            if (phase.phase == 0)
            {
                return monsterActive;
            }
            else return true;
        }
        set
        {
            monsterActive = value;
        }
    }

    public IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        LoadScene(nextScene);
    }

    public void ChangePhase()
    {
        phase.phase += 1;
    }

    public void ChangeToLastScene()
    {
        
    }
    public void EndScene()
    {

    }
    public void LoadCurrentScene()
    {
        int[] scenes = new int[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            scenes[i] = SceneManager.GetSceneAt(i).buildIndex;
        }
        LoadScene(scenes);
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
