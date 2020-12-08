using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class openstage : MonoBehaviour
{

    GameObject StageBG;
    // Start is called before the first frame update
    void Start()
    {
        StageBG = GameObject.Find("Canvas").transform.Find("StageBG").gameObject;
        if (Manager.instance.stage_on)
        {
            StageBG.SetActive(true);
            Manager.instance.stage_on = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
