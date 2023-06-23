using System;
using UnityEngine;

namespace PopUps { 

    [RequireComponent(typeof(Animator), typeof(AnimationsPopUpController))]
    public class GuidePopUpController : MonoBehaviour
    {
        private bool _isntNeedShowGuidePopUp = true;
        private AnimationsPopUpController _popPuAnimationController;
        private void Start()
        {
            _popPuAnimationController = GetComponent<AnimationsPopUpController>();
            _isntNeedShowGuidePopUp =  Convert.ToBoolean(PlayerPrefs.GetInt(nameof(_isntNeedShowGuidePopUp), 0));

            if (_isntNeedShowGuidePopUp == false)
            {
                _popPuAnimationController.PopUpAppear();
                ChangeStatusForActiveGuidePopUp();
            }
        }

        public void ChangeStatusForActiveGuidePopUp()
        {
            PlayerPrefs.SetInt(nameof(_isntNeedShowGuidePopUp), ConvertorToInt(true));
            _popPuAnimationController.PopUpAppear();
        }

        public void SaveStateAndClosedGuidPopUp()
        {
            _popPuAnimationController.PopUpDisAppear();
            PlayerPrefs.SetInt(nameof(_isntNeedShowGuidePopUp), ConvertorToInt(false));
        }

        private int ConvertorToInt(bool param)
        {
            return Convert.ToInt32((param));
        }
    }
}