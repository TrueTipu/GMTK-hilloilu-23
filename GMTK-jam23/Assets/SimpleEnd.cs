using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class SimpleEnd : MonoBehaviour
{
    [SerializeField] GameObject pum;
    int i = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            transform.position += new Vector3(5, 0, 0);
            AudioManager.Instance.Play("PUM");
            Destroy(Instantiate(pum, Vector3.zero, Quaternion.identity), 5);
            
            i++;
            if (i > 5)
            {
                AudioManager.Instance.Stop("EndTheme");
                AudioManager.Instance.Play("Ending");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
    }
}
