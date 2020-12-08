using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet's speed")]
    public float speed;

    private void Start()
    {
        Invoke("RemoveBullet", 2.5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void RemoveBullet()
    {
        Destroy(this.gameObject);
    }
}
