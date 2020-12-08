using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    BulletPattern bulletPattern;
    public float fireRate;

    void Start()
    {
        bulletPattern = GameObject.Find("FireCaller").GetComponent<BulletPattern>();
        StartCoroutine(StartEnemy());
    }
    void FireBullet()
    {
        if (transform.CompareTag("normalEnemy"))
        {
            bulletPattern.NormalPattern(transform.position);
            Invoke("FireBullet", fireRate);
            return;
        }
        switch (Manager.instance.stageCount)
        {
            case 1: bulletPattern.Pattern_1(transform.position); break;
            case 2: bulletPattern.Pattern_2(transform.position); break;
            case 3: bulletPattern.Pattern_3(transform.position); break;
            case 4: bulletPattern.Pattern_4(transform.position); break;
            case 5: bulletPattern.Pattern_5(); break;
            case 6: bulletPattern.Pattern_6(transform.position); break;
            case 7: bulletPattern.Pattern_7(transform.position); break;
            case 8: bulletPattern.Pattern_8(transform.position); break;
            //case 9: bulletPattern.Pattern_9(transform.position); break;
        }
        Invoke("FireBullet", fireRate);
    }
    IEnumerator StartEnemy()
    {
        for (byte i = 0; i < 255; i += 5)
        {
            GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, i);
            yield return new WaitForSeconds(0.01f);
        }
        FireBullet();
    }
}