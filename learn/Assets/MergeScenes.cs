using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MergeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Scenes/Player", LoadSceneMode.Additive);
        SceneManager.LoadScene("Scenes/ranking", LoadSceneMode.Additive);
        // SceneManager.LoadScene("Scenes/rankingMenu", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
