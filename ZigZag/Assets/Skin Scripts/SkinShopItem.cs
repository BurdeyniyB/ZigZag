using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShopItem : MonoBehaviour
{
  [SerializeField] private SkinManager skinManager;
  [SerializeField] private int skinIndex;
  [SerializeField] private Button buyButton;
  [SerializeField] private Text costText;
  [SerializeField] private Text StartText;
  private Skin skin;
  private Renderer playerBody;
  public int coins;

  void Update()
  {
    coins = PlayerPrefs.GetInt("diamond", 0);
    StartText.text = coins.ToString();
  }

  void Start()
  {
      playerBody = GetComponent<Renderer>();
      for (int i = 0; i <= skinManager.skins.Length; i++)
      {
          if (skinManager.IsUnlocked(i))
          {
              Debug.Log("IsUnlocked = " + i);
          }
      }
    skin = skinManager.skins[skinIndex];
    playerBody.material.mainTexture = skin.texture;

    if (skinManager.IsUnlocked(skinIndex))
    {
      buyButton.gameObject.SetActive(false);
    }
    else
    {
      buyButton.gameObject.SetActive(true);
      costText.text = skin.cost.ToString();
      if (skin.cost == 0)
      {
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
      }
    }
  }

  public void OnSkinPressed()
  {
    if (skinManager.IsUnlocked(skinIndex))
    {
      skinManager.SelectSkin(skinIndex);
    }

    PlayerPrefs.SetInt("Selected click", 1);
  }

  public void OnBuyButtonPressed()
  {
    // Unlock the skin
    if (coins >= skin.cost && !skinManager.IsUnlocked(skinIndex))
    {
          PlayerPrefs.SetInt("diamond", coins - skin.cost);
          coins = coins - skin.cost;
          skinManager.Unlock(skinIndex);
          buyButton.gameObject.SetActive(false);
          skinManager.SelectSkin(skinIndex);
          StartText.text = coins.ToString();

          PlayerPrefs.SetInt("Buy click", 1);
    }
    else
    {
      Debug.Log("Not enough star :(");
    }
  }
}
