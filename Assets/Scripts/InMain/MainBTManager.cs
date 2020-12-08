using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBTManager : MonoBehaviour
{   //This must put hierarchy's BTManager
    GameObject MainBG;
    GameObject SettingBG;
    GameObject StageBG;

    public Text BGSoundText;
    public Text ShotSoundText;

    Text StageText;
    Text InfoText;

    public Text StageBTText;

    bool isMain = true;
    bool canStart = true;
    bool sudokuStart = false;

    public float textSpanTime;

    private void Start()
    {
        Manager.instance.stageCount = 1;
        Time.timeScale = 1;

        MainBG = GameObject.Find("Canvas").transform.Find("MainBG").gameObject;
        SettingBG = GameObject.Find("Canvas").transform.Find("SettingBG").gameObject;
        StageBG = GameObject.Find("Canvas").transform.Find("StageBG").gameObject;

        StageText = StageBG.transform.Find("StageText").GetComponent<Text>();
        InfoText = MainBG.transform.Find("InfoText").GetComponent<Text>();

        DeleteInfoText();

        if (Manager.instance.BGSoundisON == true)
        {
            BGSoundText.text = "on";
            GameObject.Find("Game").GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            BGSoundText.text = "off";
            GameObject.Find("Game").GetComponent<AudioSource>().volume = 0;
        }
        if (Manager.instance.ShotSoundisON == true)
            ShotSoundText.text = "on";
        else
            ShotSoundText.text = "off";

        if (Manager.instance.clearStage[0] == true) //1스테이지가 클리어 되었는지
        {
            StageBTText.text = "CLEARED";
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isMain)
            SwitchToStage();
    }

    private void InactivateBG()//배경 오브젝트 비활성화 (초기화)
    {
        MainBG.SetActive(false);
        SettingBG.SetActive(false);
        StageBG.SetActive(false);
    }

    public void SwitchToMain_BT()//메인화면으로 전환
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        InactivateBG(); isMain = true;
        MainBG.SetActive(true);
    }
    public void SwitchToSetting_BT()//설정화면으로 전환
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        InactivateBG(); isMain = false;
        SettingBG.SetActive(true);
    }
    public void SwitchToStage()//스테이지화면으로 전환
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        InactivateBG(); isMain = false;
        StageBG.SetActive(true);
    }

    private void CheckCanStage8()//8스테이지가 열린 스테이지인지 검사
    {
        if(Manager.instance.clearStage[Manager.instance.stageCount - 1] == true) //클리어 되었는지
        {
            StageBTText.text = "CLEARED";
            return;
        }

        if (Manager.instance.canStage8 == false && Manager.instance.stageCount == 8)
        {
            StageBTText.text = "SUDOKU";
            canStart = false;
            sudokuStart = true;
        }
        else
        {
            StageBTText.text = "START";
            canStart = true;
            sudokuStart = false;
        }
    }
    private void SetStageText()//스테이지 텍스트 재정의
    {
        StageText.text = "" + Manager.instance.stageCount;
    }
    public void NextStage_BT()//스테이지 카운트 증가
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        Manager.instance.stageCount++;
        Manager.instance.stageCount = Mathf.Clamp(Manager.instance.stageCount, 1, 8);
        SetStageText();
        CheckCanStage8();
    }
    public void PreviousStage_BT()//스테이지 카운트 감소
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        Manager.instance.stageCount--;
        Manager.instance.stageCount = Mathf.Clamp(Manager.instance.stageCount, 1, 8);
        SetStageText();
        CheckCanStage8();
    }

    public void StartGame()//스테이지 시작
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        if (canStart)
            SceneManager.LoadScene("GameScene");
        else if(sudokuStart)
            SceneManager.LoadScene("SudokuScene");
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();
    }

    void DeleteInfoText()
    {
        InfoText.text = "";
        Invoke("WriteInfoText", textSpanTime);
    }
    void WriteInfoText()
    {
        InfoText.text = "PRESS THE ENTER";
        Invoke("DeleteInfoText", textSpanTime);
    }



    public void GoToSudoku()//스토쿠 시작
    {
        GameObject.Find("Menu").GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("SudokuScene");
    }

    public void SetBGSound()
    {
        if (Manager.instance.BGSoundisON == true)
        {
            BGSoundText.text = "off";
            Manager.instance.BGSoundisON = false;
            GameObject.Find("Game").GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            BGSoundText.text = "on";
            Manager.instance.BGSoundisON = true;
            GameObject.Find("Game").GetComponent<AudioSource>().volume = 1;
        }
    }
    public void SetShotSound()
    {
        if (Manager.instance.ShotSoundisON == true)
        {
            ShotSoundText.text = "off";
            Manager.instance.ShotSoundisON = false;
        }
        else
        {
            ShotSoundText.text = "on";
            Manager.instance.ShotSoundisON = true;
        }
    }
}