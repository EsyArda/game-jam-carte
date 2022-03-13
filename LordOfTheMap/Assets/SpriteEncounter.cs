using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpriteEncounter : MonoBehaviour
{


    public Texture2D LoadTexture(string FilePath)
    {
        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails
        Texture2D Tex2D;
        byte[] FileData;
        if (File.Exists(FilePath))
        {
            Debug.Log("File not empty");
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        Debug.Log("return empty");
        return null;                     // Return null if load failed
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        /*
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(this.LoadTexture("Assets / Creator Kit - RPG / Art / Dialogue / Characters / Grey_Wolf.png"),
            this.GetComponent<SpriteRenderer>().sprite.rect,
            this.GetComponent<SpriteRenderer>().sprite.pivot);
*/        
        this.GetComponent<SpriteRenderer>().color = Color.blue;
        this.transform.position += new Vector3(1, 0, 0);
    }


    // Update is called once per frame
    void Update()
    {

    }
}

