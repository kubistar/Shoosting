using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{   //Used only for Enemy

    [SerializeField] BulletController bullet1;

    private void BasePattern(Vector3 startPosition, Quaternion startRotation)
    {
        var bullet_object = Instantiate(bullet1, startPosition, startRotation);
    }

    public void NormalPattern(Vector3 startPosition)
    {
        BasePattern(startPosition, Quaternion.Euler(0, 0, 90));
    }
    //플레이어 방향으로 한 발 발사
    public void Pattern_1(Vector3 startPos)
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 dir = playerPos - startPos;
        float angle = Mathf.Atan2(playerPos.y - startPos.y, playerPos.x - startPos.x) * Mathf.Rad2Deg;
        BasePattern(startPos, Quaternion.AngleAxis(angle - 90, Vector3.forward));
    }
    //부채꼴 모양으로 다섯 발 발사(랜덤각도)
    public void Pattern_2(Vector3 startPosition)
    {
        int ran = Random.Range(5, 16);
        for (int i = 0; i < 5; i++)
            BasePattern(startPosition, Quaternion.Euler(0, 0, (ran * 5) + (i * 20)));
    }
    //맵 오른쪽에서 위 아래 간격을 두고 3발 발사
    public void Pattern_3(Vector3 startPosition)
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 dir = playerPos - startPosition;
        float angle = Mathf.Atan2(playerPos.y - startPosition.y, playerPos.x - startPosition.x) * Mathf.Rad2Deg;

        for (int i = 0; i < 5; i++)
            BasePattern(new Vector3(10, -5 + (i * 2), 0), Quaternion.Euler(0, 0, 90));

        for (int i = -1; i < 2; i++)
            BasePattern(startPosition, Quaternion.AngleAxis(angle - (i * 5 + 90), Vector3.forward));
    }
    //부채꼴 모양으로 네 발 시간 간격을 두고 발사
    public void Pattern_4(Vector3 startPosition)
    {
        StartCoroutine(IEPattern_4(startPosition));
    }
    //오른쪽 모서리 위 아래 중 하나에서 랜덤으로 다섯 발 발사
    public void Pattern_5()
    {
        int ran = Random.Range(0, 2);
        if (ran == 0)
            for (int i = 0; i < 5; i++)
                BasePattern(new Vector3(4 + (i * 2f), 5 - (i * 2f), 0), Quaternion.Euler(0, 0, 102));
        else if (ran == 1)
            for (int i = 0; i < 5; i++)
                BasePattern(new Vector3(4 + (i * 2f), -5 + (i * 2f), 0), Quaternion.Euler(0, 0, 78));
    }
    //부채꼴 모양으로 네 발 시간 간격을 두고 위 아래로 발사(랜덤, 연속으로 발사)
    public void Pattern_6(Vector3 startPosition)
    {
        StartCoroutine(IEPattern_6(startPosition));
    }
    //오른쪽에서 위 아래에서 2발 씩 간격을 좁히며 총 다섯 발을 시간 간격을 두고 발사
    //+플레이어 방향으로 부채꼴 모양으로 네 발 시간 간격을 두고 발사
    public void Pattern_7(Vector3 startPosition)
    {
        StartCoroutine(IEPattern_7(startPosition));
    }

    //5, 6, 7 패턴 랜덤 공유
    public void Pattern_8(Vector3 startPosition)
    {
        int ran = Random.Range(0, 3);
        switch (ran)
        {
            case 1: Pattern_5(); break;
            case 2: Pattern_6(startPosition); break;
            case 3: Pattern_7(startPosition); break;
        }
    }

    private void Update()
    {
        
    }

    IEnumerator IEPattern_4(Vector3 startPosition)
    {
        var bl = new List<Transform>();

        for (int i = 0; i < 4; i++)
        {
            var bullet_object = Instantiate(bullet1, startPosition, Quaternion.Euler(0, 0, 60 + (i * 20)));
            bl.Add(bullet_object.transform);
            //BasePattern(startPosition, Quaternion.Euler(0, 0, 60 + (i * 20)));
            yield return new WaitForSeconds(0.05f);
        }

        StartCoroutine(BulletToTarget(bl));
    }
    IEnumerator IEPattern_6(Vector3 startPosition)
    {
        int ran = Random.Range(2, 6);

        for (int i = 0; i < 5; i++)
        {
            BasePattern(startPosition, Quaternion.Euler(0, 0, 60 + (i * (ran * 10))));
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < 5; i++)
        {
            BasePattern(startPosition, Quaternion.Euler(0, 0, 120 - (i * (ran * 10))));
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator IEPattern_7(Vector3 startPosition)
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 dir = playerPos - startPosition;
        float angle = Mathf.Atan2(playerPos.y - startPosition.y, playerPos.x - startPosition.x) * Mathf.Rad2Deg;
        int ran = Random.Range(0, 2);

        for (int i = 0; i < 2; i++)
        {
            BasePattern(new Vector3(10, -4 + (i * 2), 0), Quaternion.Euler(0, 0, 90));
            BasePattern(new Vector3(10, 4 - (i * 2), 0), Quaternion.Euler(0, 0, 90));

            yield return new WaitForSeconds(0.4f);
        }

        for (int j = -1; j < 3; j++)
            BasePattern(startPosition, Quaternion.AngleAxis(angle - (j * 20 + 90), Vector3.forward));

        BasePattern(new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(0.4f);
    }

    IEnumerator BulletToTarget(List<Transform> bullet_list)
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        //0.5초 후에 시작
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < bullet_list.Count; i++)
        {
            //현재 총알의 위치에서 플레이의 위치의 벡터값을 뻴셈하여 방향을 구함
            var target_dir = playerPos - bullet_list[i].position;

            //x,y의 값을 조합하여 Z방향 값으로 변형함. -> ~도 단위로 변형
            var angle = Mathf.Atan2(target_dir.y, target_dir.x) * Mathf.Rad2Deg;

            //Target 방향으로 이동
            bullet_list[i].rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        //데이터 해제
        bullet_list.Clear();
    }
}
