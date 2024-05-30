using System.Collections;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public static CoroutineRunner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //to protect after a new game, can comment if not needed
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public static void EnsureInstance()
    {
        if (Instance == null)
        {
            GameObject runner = new GameObject("CoroutineRunner");
            Instance = runner.AddComponent<CoroutineRunner>();
            DontDestroyOnLoad(runner);  //to protect after a new game, can comment if not needed
        }
    }
}
