using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    static public bool isEnd = false;
    int healthPoint = 5;
    public Image[] HeartImgs = new Image[5];
    GameObject DefeatBG;
    private void Start()
    {
        isEnd = false;
        DefeatBG = GameObject.Find("Canvas").transform.Find("DefeatBG").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            if (PlayerState.isEnd)
                return;
            healthPoint--;

            DecreaseHeart();
            CheckAlive();

            Destroy(collision.gameObject);
        }
    }
    private void CheckAlive()
    {
        if (healthPoint <= 0)
        {
            DefeatBG.SetActive(true);
            isEnd = true;
            GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);

            GameObject.Find("Death").GetComponent<AudioSource>().Play();
            GameObject.Find("Over").GetComponent<AudioSource>().Play();
            GameObject.Find("Game").GetComponent<AudioSource>().Stop();
        }
    }
    private void DecreaseHeart()
    {
        if(healthPoint >= 0)
            HeartImgs[healthPoint].color = new Color32(0, 0, 0, 255);
    }
}
