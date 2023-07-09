using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject particles;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] SpriteRenderer sp2;
    bool wait = true;
    private void Start()
    {
        MusicPlayer.Instance.SetSourceActive(0);
        AudioManager.Instance.Play("EndTheme");
        StartCoroutine(TransSukupuolinenIhminen());
    }

    IEnumerator TransSukupuolinenIhminen()
    {
        Debug.Log("a");
        while (sp.color.a < 1)
        {
            Debug.Log("b");
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a + 0.01f);
            sp2.color = new Color(sp2.color.r, sp2.color.g, sp2.color.b, sp2.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        wait = false;
    }
    void Update()
    {
        if (wait) return;
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime);
        }
        if(transform.position.y < -90)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var a = Instantiate(particles, new Vector3(transform.position.x, collision.transform.position.y), Quaternion.identity);
            AudioManager.Instance.PlayRandom(new string[] { "Mor1", "Mor2", "Mor3", "Mor4", "Mor5", "Mor6", });
            AudioManager.Instance.PlayRandom(new string[] { "Mor1", "Mor2", "Mor3", "Mor4", "Mor5", "Mor6", });
            AudioManager.Instance.PlayRandom(new string[] { "Mor1", "Mor2", "Mor3", "Mor4", "Mor5", "Mor6", });
            AudioManager.Instance.PlayRandom(new string[] { "Mor1", "Mor2", "Mor3", "Mor4", "Mor5", "Mor6", });
            Destroy(a, 3);
            Destroy(collision.gameObject);
        }
    }
}
