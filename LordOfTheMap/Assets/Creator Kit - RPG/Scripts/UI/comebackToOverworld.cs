using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comebackToOverworld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Comeback()
    {
        SceneManager.LoadScene("Lotr");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
