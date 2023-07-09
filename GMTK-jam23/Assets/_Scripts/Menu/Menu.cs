using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play("TitleTheme");
        AudioManager.Instance.MusicPlayer.gameObject.SetActive(false);
    }


    [SerializeField] Animator anim;
    public void PlayGame()
    {
        AudioManager.Instance.Stop("TitleTheme");
        AudioManager.Instance.MusicPlayer.gameObject.SetActive(true);
        AudioManager.Instance.MusicPlayer.Init();
        Time.timeScale = 1;
        StartCoroutine(LoadNextScene());
        anim.SetTrigger("Trans");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

}