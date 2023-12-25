using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SceneLoader", order = 1)]
public class SceneLoader : ScriptableObject
{
    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void LoadDemoScene()
    {
        SceneManager.LoadScene("DemoScene");
    }

    
}
