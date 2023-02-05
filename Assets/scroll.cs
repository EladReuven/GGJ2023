using System.Threading;
using UnityEngine;

public class scroll : MonoBehaviour
{
    private Renderer rend;
    public float scrollSpeed = 0.5f;
    bool pressed = false;
    float timer;
    void Start()
    {
        rend = GetComponent<Renderer>();
        timer = 0;
    }

    void Update()
    {
        if (timer <= 0) {
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && !pressed)
        {
            float timer = 0.5f;
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
        timer -= Time.deltaTime;
    }
}