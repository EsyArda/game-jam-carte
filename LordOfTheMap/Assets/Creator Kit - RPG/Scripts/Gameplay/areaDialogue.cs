using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class areaDialogue : MonoBehaviour
{
    // Start is called before the first frame update


    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("DialogueBlankScene");
    }

    // Update is called once per frame

}
