using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour
{
    public Image HPbar;
    GameObject ClearBG;

    public float healthPoint;
    private float currentHP;

    public bool isBoss;

    void Start()
    {
        currentHP = healthPoint;
        ClearBG = GameObject.Find("Canvas").transform.Find("ClearBG").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TeamBullet"))
        {
            currentHP--;
            HPbar.fillAmount = currentHP / healthPoint;
            Debug.Log(currentHP / healthPoint);
            CheckAlive();

            Destroy(collision.gameObject);
        }
    }
    private void CheckAlive()
    {
        if (currentHP <= 0)
        {
            if (!isBoss)
            {
                Destroy(this.gameObject);
            }
            else
            {
                ClearBG.SetActive(true);
                Destroy(this.gameObject);
                //RewardRanNumber();
                CheckAlreadyClear();

                GameObject.Find("ButtonManager").GetComponent<GameButtonManager>().CheckCanNextGame();
                PlayerState.isEnd = true;
 
                Manager.instance.clearStage[Manager.instance.stageCount - 1] = true;

                GameObject.Find("Clear").GetComponent<AudioSource>().Play();
                GameObject.Find("Game").GetComponent<AudioSource>().Stop();

                /* if(Manager.instance.stageCount != 8)
                     Manager.instance.clearStage[Manager.instance.stageCount - 1] = 1; */
            }
        }
    }
    private void RewardRanNumber()
    {
        int ran = Random.Range(0, 7);
        if (Manager.instance.haveNumber[ran] == true) //이미 얻은 숫자라면 재 실행
        {
            RewardRanNumber();
            return;
        }
        else
        {
            Manager.instance.haveNumber[ran] = true;
            GameObject.Find("RewardNumText").GetComponent<Text>().text = GetRewardNum(ran).ToString();
        }
    }
    int GetRewardNum(int num)
    {
        int result = 0;
        switch (num)
        {
            case 0: result = 1; break;
            case 1: result = 1; break;
            case 2: result = 2; break;
            case 3: result = 2; break;
            case 4: result = 2; break;
            case 5: result = 3; break;
            case 6: result = 4; break;
            case 7: result = 4; break;
        }
        return result;
    }
    void CheckAlreadyClear()
    {
        if (Manager.instance.stageCount == 8)
        {
            GameObject.Find("RewardNumText").GetComponent<Text>().text = "X";
            return;
        }
        if (Manager.instance.clearStage[Manager.instance.stageCount - 1] == true) //이미 클리어한 스테이지라면 보상 없음
        {
            GameObject.Find("RewardNumText").GetComponent<Text>().text = "X";
            return;
        }
        else
        {
            if (Manager.instance.stageCount == 7)
            {
                Manager.instance.haveNumberOne = true;
            }
            RewardRanNumber();
        }
    }
}
