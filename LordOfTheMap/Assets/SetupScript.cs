using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetupScript : MonoBehaviour
{

    public string Backgound;



    // Start is called before the first frame update
    void Start()
    {
        GameObject liste = this.GetComponent<GameObject>();
        liste.SetActive(false);
        Transform rencontre = transform.Find(Backgound);
        Debug.Log(liste);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
