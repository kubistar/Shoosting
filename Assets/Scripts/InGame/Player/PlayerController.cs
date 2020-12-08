using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    [Header("Limit range")]
    public float limitX_Right = 1; //1
    public float limitX_Left = -8.3f; //-8.3
    public float limitY_Up = 4; //-4
    public float limitY_Down = -4; //4
    [Header("Firing's distance")]
    public float spanFire;
    private float delta;
    [Header("Bullet")]
    public BulletController bulletPrefab;

    void Start()
    {
        
    }
    void Update()
    {
        MovePlayer();
        LockUpPlayer();
        FireBullet();
    }
    void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float v = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        transform.Translate(h * speed, v * speed, 0);
    }
    void LockUpPlayer()
    {
        if (this.transform.position.x > this.limitX_Right)
            this.transform.position = new Vector2(this.limitX_Right, this.transform.position.y);
        if (this.transform.position.x < this.limitX_Left)
            this.transform.position = new Vector2(this.limitX_Left, this.transform.position.y);

        if (this.transform.position.y > this.limitY_Up)
            this.transform.position = new Vector2(this.transform.position.x, this.limitY_Up);
        if (this.transform.position.y < this.limitY_Down)
            this.transform.position = new Vector2(this.transform.position.x, this.limitY_Down);
    }
    void FireBullet()
    {
        if (PlayerState.isEnd)
            return;
        if (!Input.GetMouseButton(0))
            return;

        GameObject.Find("Shot").GetComponent<AudioSource>().Play();

        delta += Time.deltaTime;
        if (delta > spanFire)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0.6f, 0.4f, 0), Quaternion.Euler(0, 0, -90));
            delta = 0;
        }
    }
}
