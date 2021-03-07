using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.LoadLevelAdditive("Scenes/Player");
        Application.LoadLevelAdditive("Scenes/ranking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
