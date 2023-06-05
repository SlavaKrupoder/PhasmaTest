using UnityEngine;
using UnityEngine.Localization.Components;
using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(Animator), typeof(LocalizeStringEvent))]
public class DescriptionPopUpController : MonoBehaviour
{
    [SF] private LocalizeStringEvent _localStringEvent;
    [SF] private Animator _popUpAnimator;
    [SF] private TMPro.TextMeshProUGUI _descriptionText;

    private void Start()
    {
        if (_popUpAnimator == null)
        {
            _popUpAnimator = GetComponent<Animator>();
        }
        if(_localStringEvent == null)
        {
            _localStringEvent = GetComponent<LocalizeStringEvent>();
        }
    }
    public void SetDescriptionInfo(string descriptionGhostTabel, string localDescriptKey)
    {

        _localStringEvent.SetTable(descriptionGhostTabel);
        _localStringEvent.SetEntry(localDescriptKey);
        _localStringEvent.RefreshString();
        _descriptionText.text = _descriptionText.text.Replace("\\n", "\n");
    }

    public void PopUpAppear()
    {
        _popUpAnimator.SetTrigger("Appear");
    }

    public void PopUpDisAppear()
    {
        _popUpAnimator.SetTrigger("DisAppear");
    }

}
