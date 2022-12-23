using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoModeButton : MonoBehaviour
{
   public Sprite imTrue;
   public Sprite imFalse;
   private int control;
   public Image image;

   void Update()
   {
     control = PlayerPrefs.GetInt("AutoMode");
     if(control == 1){
      image.sprite = imTrue;
     }
     else{
      image.sprite = imFalse;
     }
   }

   public void AutoMode()
   {
     PlayerPrefs.SetInt("Click", 1);
     if(control == 0)
     {
     PlayerPrefs.SetInt("AutoMode", 1);
     image.sprite = imTrue;
     }
     else
     {
     PlayerPrefs.SetInt("AutoMode", 0);
     image.sprite = imFalse;
     }
   }

}
