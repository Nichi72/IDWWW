using UnityEngine;
using System.Collections;

public class UVScroller : MonoBehaviour
{
    public enum ScrollDirection : int
    {
        None, Horizontal, Vertical, Both
    }

    public ScrollDirection direction;
    public float moveSpeed = 10;
    private float delta = 0.02f;

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        switch (direction)
        {
            case ScrollDirection.Horizontal: // 1 
                GetComponent<Renderer>().material.mainTextureOffset += new Vector2(moveSpeed * delta * delta, 0f);
                break;
            case ScrollDirection.Vertical: // 2
                GetComponent<Renderer>().material.mainTextureOffset += new Vector2(0f, moveSpeed * delta * delta);
                break;
            case ScrollDirection.Both://3
                GetComponent<Renderer>().material.mainTextureOffset += new Vector2(moveSpeed * delta * delta, moveSpeed * delta * delta);
                break;
            default:
                break;
        }
    }
}