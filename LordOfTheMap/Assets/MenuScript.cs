using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //(SceneManager.GetActiveScene().name != "Lotr")
        {
            SceneManager.LoadScene("Lotr");
        }
    }
}