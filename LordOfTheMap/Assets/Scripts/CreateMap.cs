using System.IO;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public Vector3 coord;
    public Texture2D LoadTexture(string FilePath)
    {
        // Load a PNG or JPG file from disk to a Texture2D
        // Returns null if load fails
        Texture2D Tex2D;
        byte[] FileData;
        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
            if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                return Tex2D;                 // If data = readable -> return texture
        }
        return null;                     // Return null if load failed
    }

    // Start is called before the first frame update
    void Start()
    {
        string dirPath = "Assets/Tiles/";
        string filePath;
        float pixelsPerUnit = 100.0f;
        int pas = 4; // 4 ou 16

        int w = 200; // Largeur img
        int h = 200; // Hauteur img

        Rect r;

        for (int zone = 1; zone < 2; zone++)
        // Eriador : 1, Rhovanion : 2, Gondor : 3, Mordor : 4
        {
            for (int line = 1; line <= 1; line += pas)
            {
                coord.x = 0;
                for (int col = 25; col <= 41; col += pas)
                {
                    // Créer la texture
                    filePath = dirPath + $"{zone}_{line}_{col}_{pas}.jpg";
                    Debug.Log(filePath);
                    Texture2D spriteTexture = LoadTexture(filePath);
                    w = spriteTexture.width;
                    h = spriteTexture.height;

                    // Créer sprite
                    r = new Rect(0, 0, w, h);
                    Sprite sprite = Sprite.Create(spriteTexture, r, Vector2.zero, pixelsPerUnit);

                    // Render
                    GameObject spriteGameObject = new GameObject("spriteGameObject", typeof(SpriteRenderer));
                    SpriteRenderer sr = spriteGameObject.GetComponent<SpriteRenderer>();
                    Debug.Log(sr.transform.position);
                    sr.sortingOrder = -1;
                    sr.sprite = sprite;
                    sr.transform.position = coord;


                    // Mise a jour des variables
                    coord.x += w;
                }
                coord.y += h;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}