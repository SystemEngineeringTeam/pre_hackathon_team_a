using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu2UI : MonoBehaviour
{
    public void ChangeScene2Sample()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void ChangeScene2Game()
    {
        SceneManager.LoadScene("naruse01");
    }
}
