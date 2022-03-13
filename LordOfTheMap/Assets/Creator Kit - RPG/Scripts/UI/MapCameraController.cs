using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapCameraController : MonoBehaviour
{
    public int speed = 3;
    private Vector3 targetGo;
    private Vector3 targetGoBack;

    void Start()
    {
        float step = speed;
        targetGo = new Vector3(960, 540,0);
        targetGoBack = new Vector3(960, -500,0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetGo, speed);
            GameObject.Find("Map Camera").GetComponent<Camera>().enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            transform.position = Vector3.MoveTowards(transform.position, targetGoBack, speed);
            GameObject.Find("Map Camera").GetComponent<Camera>().enabled = true;
        }
    }
}