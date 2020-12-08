using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public float spownBossSpan;
    public float spownSpan;

    public GameObject Jellyfish;
    public GameObject Octopus;
    public GameObject Seahorse;
    public GameObject Turtle;
    public GameObject Spearfish;
    public GameObject Sunfish;
    public GameObject Squid;
    public GameObject tempEnemy0;
    public GameObject tempEnemy1;
    public GameObject tempEnemy2;

    public GameObject Reward1;
    public Text Reward1Text;

    void Start()
    {
        spownSpan = spownSpan - (Manager.instance.stageCount * 0.05f);
        Invoke("ActivateBoss", spownBossSpan);
        Invoke("CreateEnemy", spownSpan);
        if (Manager.instance.stageCount == 7)
            Reward1.SetActive(true);

        if (!Manager.instance.BGSoundisON)
            GameObject.Find("Game").GetComponent<AudioSource>().volume = 0;
        if (!Manager.instance.ShotSoundisON)
            GameObject.Find("Shot").GetComponent<AudioSource>().volume = 0;

        if (Manager.instance.clearStage[Manager.instance.stageCount - 1] == true) //이미 클리어한 스테이지라면 보상 없음
            Reward1Text.text = "X";
    }
    void CreateEnemy()
    {
        float ranX = Random.Range(2.6f, 3.6f);
        float ranY = Random.Range(-3.7f, 3.7f);
        Instantiate(Jellyfish, new Vector3(ranX, ranY, 0), Quaternion.identity);
        Invoke("CreateEnemy", spownSpan);
    }
    void ActivateBoss()
    {
        switch (Manager.instance.stageCount)
        {
            case 1: Octopus.SetActive(true); break;
            case 2: Seahorse.SetActive(true); break;
            case 3: Turtle.SetActive(true); break;
            case 4: Spearfish.SetActive(true); break;
            case 5: Sunfish.SetActive(true); break;
            case 6: Squid.SetActive(true); break;
            case 7: tempEnemy0.SetActive(true); break;
            case 8: tempEnemy1.SetActive(true); break;
            case 9: tempEnemy2.SetActive(true); break;
        }
    }
}
