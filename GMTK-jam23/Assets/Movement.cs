using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject particles;
    private void Start()
    {
        MusicPlayer.Instance.SetSourceActive(0);
        AudioManager.Instance.Play("EndTheme");
    }
    void Update()
    {
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
