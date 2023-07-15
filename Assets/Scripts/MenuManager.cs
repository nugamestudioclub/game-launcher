using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Image image;
    // Start is called before the first frame update
    void Awake()
    {
        using var process = new Process();

        process.StartInfo.FileName = "C:\\WINDOWS\\system32\\notepad.exe";
        process.StartInfo.UseShellExecute = true;
        process.Start();
        string imagePath = "C:\\Users\\sebas\\Downloads\\rootkit_screenshot3.png";
        var bytes = System.IO.File.ReadAllBytes(imagePath);
        var texture = new Texture2D(2, 2);
        UnityEngine.Debug.Log($"Texture dimensions before load: ({texture.width}, {texture.height})");
        texture.LoadImage(bytes);
        UnityEngine.Debug.Log($"Texture dimensions after load: ({texture.width}, {texture.height})");
        image.sprite = Sprite.Create(
            texture, 
            new Rect(0.0f, 0.0f, texture.width, texture.height), 
            new Vector2(0.5f, 0.5f), 100.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
