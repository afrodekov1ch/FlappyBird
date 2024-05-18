using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetInt("audioTrue") == 0)
        {
            PlayerPrefs.SetFloat("volume", 1);
        }
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}