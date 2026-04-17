using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObject : MonoBehaviour
{
    public static string staticPublicDebugText = "";
    private static string staticPrivateDebugText = "";
    private string instancePrivateDebugText = "instance private";
    public string instancePublicDebugText = "instance public";
    //1
    private static PersistentObject staticInstance = null;
    //2
    public static PersistentObject GetInstance()
    {//3
        return staticInstance;
    }

    void Awake()
    {
        //4
        if (staticInstance != null)
        {
            Destroy(this.gameObject);
            return;        
        }

        DontDestroyOnLoad(gameObject);
        //5 Important
        staticInstance  = this;
    }

    void Start()
    {
        staticPublicDebugText = "Hello (public)";
        staticPrivateDebugText = "Hello (private)";
        StartCoroutine(Loop());

        GameSettings.volume = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Load Scene Singleton02");
            SceneManager.LoadScene("Singleton02");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Loop()
    {
        while (true)
        {
            Debug.Log($"static - publicDebugText: {staticPublicDebugText}");
            Debug.Log($"static - privateDebugText: {staticPrivateDebugText}");
            Debug.Log($"instance - publicDebugText: {instancePublicDebugText}");
            Debug.Log($"instance - privateDebugText: {instancePrivateDebugText}");
            yield return new WaitForSeconds(1);
        }
    }

    public static void SetStaticPrivateText(string text)
    {
        staticPrivateDebugText = text;
        
    }

    public void SetInstancePrivateText(string text)
    {
        instancePrivateDebugText = text;
        staticPrivateDebugText = "xxx";
    }

}
