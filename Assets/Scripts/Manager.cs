using UnityEngine;

public class Manager : MonoBehaviour
{   //This must put hierarchy's Manager
    public static Manager instance;

    [Range(1, 8)]
    public int stageCount;

    public bool[] clearStage = new bool[8];

    public bool[] haveNumber = new bool[7]; //[0=1][1=1][2=2][3=2][4=2][5=3][6=4]
    //public bool[] haveNumber = new bool[7] { false, false, false, false, false, false, false };
    public bool haveNumberOne;

    public bool canStage8 = false;

    public bool BGSoundisON;
    public bool ShotSoundisON;

    public bool stage_on = false;

    private void Awake()
    {
        if (instance == null) 
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
