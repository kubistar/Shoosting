using UnityEngine;

public class BGScrolling : MonoBehaviour
{
    public float ScrollSpeed = 0.4f;
    float Offset;

    void Update()
    {
        Offset += Time.deltaTime * ScrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Offset, 0);
    }
}
