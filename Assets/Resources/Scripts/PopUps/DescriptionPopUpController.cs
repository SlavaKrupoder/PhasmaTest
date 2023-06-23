using UnityEngine;
using UnityEngine.Localization.Components;
using SF = UnityEngine.SerializeField;

namespace PopUps
{
    [RequireComponent(typeof(LocalizeStringEvent))]
    public class DescriptionPopUpController : MonoBehaviour
    {
        [SF] private LocalizeStringEvent _ghostDescriptionlocalStringEvent;
        [SF] private LocalizeStringEvent _evidenceStringEvent;
        [SF] private Animator _popUpAnimator;
        [SF] private TMPro.TextMeshProUGUI _descriptionText;

        private void Start()
        {
            if (_ghostDescriptionlocalStringEvent == null)
            {
                _ghostDescriptionlocalStringEvent = GetComponent<LocalizeStringEvent>();
            }
        }
        public void SetDescriptionInfo(string descriptionGhostTabel, string localDescriptKey)
        {
            _ghostDescriptionlocalStringEvent.SetTable(descriptionGhostTabel);
            _ghostDescriptionlocalStringEvent.SetEntry(localDescriptKey);
            _ghostDescriptionlocalStringEvent.RefreshString();
            _descriptionText.text = _descriptionText.text.Replace("\\n", "\n");
        }

        public void SetGhostEvidenceText(string localEvidenceKey)
        {
            _evidenceStringEvent.SetEntry(localEvidenceKey);
        }

    }
}