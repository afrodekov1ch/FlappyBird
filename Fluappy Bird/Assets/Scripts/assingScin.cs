using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assingScin : MonoBehaviour
{
    public Sprite[] skins;
    public GameObject Player;

    void Start()
    {
        int skinNum = PlayerPrefs.GetInt("skinNum", 0);
        Player.GetComponent<SpriteRenderer>().sprite = skins[skinNum];
    }
}
