/*
 * 使用步骤，创建一个RenderTexture纹理，运行游戏即可生成一张截图
 * 该脚本生成的截图都是2的幂次方
 */
using UnityEngine;  
using System.IO;  
  
// [AddComponentMenu("ArtTools/ScreenShotFromCamera")]  
public class ScreenShotFromCamera : MonoBehaviour  
{  
    public RenderTexture rt;  
  
    void Start()  
    {  
        Invoke("ConvertToPNG", 1.0f);  
    }  
  
    private void ConvertToPNG()  
    {  
        if (rt == null)  
        {  
            Debug.LogError("RenderTexture is not assigned!");  
            return;  
        }  
  
        RenderTexture.active = rt;  
        Texture2D tex = new Texture2D(rt.width, rt.height, TextureFormat.RGBA32, false);  
        tex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);  
        tex.Apply(); // Ensure the texture is updated  
  
        byte[] bytes = tex.EncodeToPNG();  
        string path = Path.Combine(Application.persistentDataPath, "ScreenShot", "Picture.png");  
  
        // Ensure the directory exists  
        Directory.CreateDirectory(Path.GetDirectoryName(path));  
  
        try  
        {  
            File.WriteAllBytes(path, bytes);  
            Debug.Log("Screenshot saved to " + path);  
        }  
        catch (System.Exception e)  
        {  
            Debug.LogError("Failed to save screenshot: " + e.Message);  
        }  
  
        // Optionally, destroy the texture to free up memory  
        // Destroy(tex);  
    }  
}