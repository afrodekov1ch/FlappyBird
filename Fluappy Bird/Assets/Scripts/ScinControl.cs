using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScinControl : MonoBehaviour
{
    public int skinNum;
    public Button buyButton;
    public Image iLock;
    public int price;

    public Sprite buySkin;
    public Sprite equipped;
    public Sprite equip;
    public Sprite falseLock;
    public Sprite trueLock;

    public Image[] skins;

    private void Start()
    {
        if (PlayerPrefs.GetInt("scin1" + "buy") == 0)
        {
            foreach (Image img in skins)
            {
                if ("scin1" == img.name)
                {
                    PlayerPrefs.SetInt("scin1" + "buy", 1);
                    PlayerPrefs.SetInt("scin1" + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "buy", 0);
                }
            }
        }
    }

    private void Update()
    {
        string skinName = GetComponent<Image>().name;

        if (PlayerPrefs.GetInt(skinName + "buy") == 0)
        {
            iLock.sprite = falseLock;
            buyButton.image.sprite = buySkin;
        }
        else if (PlayerPrefs.GetInt(skinName + "buy") == 1)
        {
            iLock.sprite = trueLock;
            if (PlayerPrefs.GetInt(skinName + "equip") == 1)
            {
                buyButton.image.sprite = equipped;
            }
            else if (PlayerPrefs.GetInt(skinName + "equip") == 0)
            {
                buyButton.image.sprite = equip;
            }
        }
    }

    public void Buy()
    {
        string skinName = GetComponent<Image>().name;

        if (PlayerPrefs.GetInt(skinName + "buy") == 0)
        {
            if (GameManager.Instance.Coins >= price)
            {
                iLock.sprite = trueLock;
                buyButton.image.sprite = equipped;
                GameManager.Instance.DeductCoins(price);

                PlayerPrefs.SetInt(skinName + "buy", 1);
                PlayerPrefs.SetInt("skinNum", skinNum);

                foreach (Image img in skins)
                {
                    if (skinName == img.name)
                    {
                        PlayerPrefs.SetInt(skinName + "equip", 1);
                    }
                    else
                    {
                        PlayerPrefs.SetInt(img.name + "equip", 0);
                    }
                }
            }
        }
        else if (PlayerPrefs.GetInt(skinName + "buy") == 1)
        {
            iLock.sprite = trueLock;
            buyButton.image.sprite = equipped;
            PlayerPrefs.SetInt(skinName + "equip", 1);
            PlayerPrefs.SetInt("skinNum", skinNum);

            foreach (Image img in skins)
            {
                if (skinName == img.name)
                {
                    PlayerPrefs.SetInt(skinName + "equip", 1);
                }
                else
                {
                    PlayerPrefs.SetInt(img.name + "equip", 0);
                }
            }
        }
    }
}
