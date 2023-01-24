using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using HelperPSR.Object;
using Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI titleText;
   [SerializeField] private TextMeshProUGUI descriptionText;
   [SerializeField] private Image background;
   const float enterPopUpTime = 2;
   const float exitPopUpTime = 2;
   const int stayPopUpTime = 3000;
   const int delayBeforeEnterPopUp = 1000;

   
   public async void InitPopUp(PopUpData popUpData,Action<PopUp> endPopUp)
   {
       ResetPopUp();
       await UniTask.Delay(delayBeforeEnterPopUp, DelayType.Realtime); 
       titleText.text = popUpData.title;
       descriptionText.text = popUpData.description;
       background.color = popUpData.colorBackground;
       transform.DOScale(1, enterPopUpTime).OnComplete(()=>Stay(endPopUp));
   }

   async void Stay(Action<PopUp> endPopUp)
   {
       await UniTask.Delay(stayPopUpTime, DelayType.Realtime); 
       transform.DOScale(0, exitPopUpTime).SetEase(Ease.Linear).OnComplete(()=>endPopUp(this));
   }

   void ResetPopUp()
   {
       titleText.text = "";
       descriptionText.text = "";
       background.color = Color.clear;
       
       transform.DOScale(0, 0);

   }
   
}
