using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SudokuManager : MonoBehaviour
{
    public Image[] items = new Image[7];
    public Image item1;
    GameObject StageBG;
    Text StageText;

    void Start()
    {
        panelcheck.count = 8;
        CheckHaveNum();

        StageBG = GameObject.Find("Canvas").transform.Find("StageBG").gameObject;

        StageText = StageBG.transform.Find("StageText").GetComponent<Text>();
    }

    void Update()
    {
        
    }
    void CheckHaveNum()
    {
        if (Manager.instance.haveNumberOne == true)
        {
            item1.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            item1.color = new Color32(0, 0, 0, 255);
            item1.raycastTarget = false;
        }
        for (int i = 0; i < 7; i++)
        {
            if (Manager.instance.haveNumber[i] == true)
            {
                items[i].color = new Color32(255, 255, 255, 255);
            }
            else
            {
                items[i].color = new Color32(0, 0, 0, 255);
                items[i].raycastTarget = false;
            }
        }
    }
    public void GoToMain()//메인으로
    {
        if (panelcheck.count <= 0)
            Manager.instance.canStage8 = true;

        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        Manager.instance.stage_on = true;
        SceneManager.LoadScene("MainScene");
    }

    public void GoTo8()//8 스테이지
    {
        if (panelcheck.count <= 0)
        {
            Manager.instance.canStage8 = true;
            Manager.instance.stageCount++;
        }

        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("GameScene");
    }
}
