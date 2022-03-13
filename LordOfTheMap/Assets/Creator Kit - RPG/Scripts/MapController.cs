using UnityEngine;
using System.Collections;

public class MapController : MonoBehaviour
{
    public int sortingOrder = 0;
    private SpriteRenderer sprite;
    public int sortingOrder2 = 1000;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (sprite)
                sprite.sortingOrder = sortingOrder;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (sprite)
                sprite.sortingOrder = sortingOrder2;
        }
    }
}