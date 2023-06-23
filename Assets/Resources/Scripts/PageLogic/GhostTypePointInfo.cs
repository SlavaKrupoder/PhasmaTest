using TMPro;
using UnityEngine;
using static GhostsEvidenceData;
using SF = UnityEngine.SerializeField;
using UnityEngine.Localization.Components;
using PopUps;

namespace PageLogic
{
    [RequireComponent(typeof(LocalizeStringEvent))]
    public class GhostTypePointInfo : MonoBehaviour
    {
        [SF] private GameObject _wrongVariantLine;
        [SF] private GameObject _trueVariantLine;
        [SF] private TextMeshProUGUI _ghostTypeName;
        [SF] private ObjectParameters _ghostEvidenceParams;
        private LocalizeStringEvent _ghostDescriptionLocStringEvent;
        private DescriptionPopUpController _descriptionPopUp;
        private string _ghostName;
        private string _descriptionGhostTabel;
        private readonly string Descript = "Descript";
        private readonly string Evidences = "Evidences";

        public void SetLocalizeGhostInfo(string nameGhostTabel, string ghostName, string ghostLabel)
        {
            _ghostDescriptionLocStringEvent = GetComponent<LocalizeStringEvent>();
            _ghostDescriptionLocStringEvent.SetTable(nameGhostTabel);
            _ghostDescriptionLocStringEvent.SetEntry(ghostName + ghostLabel);
            _ghostDescriptionLocStringEvent.RefreshString();
            _ghostName = ghostName;
        }

        public void SetGhosDescriptionInfo(string descriptionGhostTabel, ObjectParameters ghostEvidenceParams)
        {
            _descriptionGhostTabel = descriptionGhostTabel;
            _ghostEvidenceParams = ghostEvidenceParams;
        }

        public ObjectParameters GetGhostEvidenceParams()
        {
            return _ghostEvidenceParams;
        }

        public void SetPopUpDescription(DescriptionPopUpController popUp)
        {
            _descriptionPopUp = popUp;
        }

        public void ShowGhostInfo()
        {
            var localDescriptKey = _ghostName + nameof(Descript);
            _descriptionPopUp.SetDescriptionInfo(_descriptionGhostTabel, localDescriptKey);
            var evidenceLocKey = _ghostName + nameof(Evidences);
            _descriptionPopUp.SetGhostEvidenceText(evidenceLocKey);
            _descriptionPopUp.gameObject.GetComponent<AnimationsPopUpController>().PopUpAppear();
        }

        public void UpdateGhostStatus(GhostStatus isWrongGhost)
        {
            switch (isWrongGhost)
            {
                case GhostStatus.UnActive:
                    _wrongVariantLine.SetActive(false);
                    _trueVariantLine.SetActive(false);
                    break;
                case GhostStatus.WrongGhost:
                    _wrongVariantLine.SetActive(true);
                    _trueVariantLine.SetActive(false);
                    break;
                case GhostStatus.WrightGhost:
                    _wrongVariantLine.SetActive(false);
                    _trueVariantLine.SetActive(true);
                    break;
                default:
                    _wrongVariantLine.SetActive(false);
                    _trueVariantLine.SetActive(false);
                    break;
            }

        }
    }

    public enum GhostStatus
    {
        UnActive = 0,
        WrongGhost,
        WrightGhost,
    }
}