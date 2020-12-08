using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonManager : MonoBehaviour
{
    public GameObject PauseBG;
    public GameObject NextBT;

    private void Start()
    {
        Time.timeScale = 1;
        if(Manager.instance.stageCount == 8)
        {
            NextBT.SetActive(false);
        }
    }
    public void BackToMain()
    {
        Manager.instance.stage_on = true;
        SceneManager.LoadScene("MainScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseBG.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        PauseBG.SetActive(false);
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void NextGame()
    {
        Manager.instance.stageCount++;
        SceneManager.LoadScene("GameScene");
    }
    public void CheckCanNextGame()
    {
        int Key = 0;

        for (int i = 0; i < Manager.instance.clearStage.Length; i++)
            //Key += Manager.instance.clearStage[i]; //클리어 스테이지를 더한 총 값이 7이면 8스테이지 가능

        if (Key != 7 && Manager.instance.stageCount == 7)
            NextBT.SetActive(false);
    }

}
