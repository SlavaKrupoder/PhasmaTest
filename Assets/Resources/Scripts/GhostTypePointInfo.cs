using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using static GhostsEvidenceData;
using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(LocalizeStringEvent))]
public class GhostTypePointInfo : MonoBehaviour
{
    [SF] private GameObject _wrongVariantLine;
    [SF] private GameObject _trueVariantLine;
    [SF] private TextMeshProUGUI _ghostTypeName;
    [SF] private ObjectParameters _ghostEvidenceParams;
    private LocalizeStringEvent _locStringEvent;
    private DescriptionPopUpController _descriptionPopUp;
    private string _ghostName;
    private string _descriptionGhostTabel;
    private readonly string Descript = "Descript";
   
    public void SetGhostInfo(string nameGhostTabel, string ghostName, string ghostLabel)
    {
        _locStringEvent = GetComponent<LocalizeStringEvent>();
        _locStringEvent.SetTable(nameGhostTabel);
        _locStringEvent.SetEntry(ghostName + ghostLabel);
        _locStringEvent.RefreshString();
        _ghostName = ghostName;
    }

    public void SetGhosDescriptionInfo(string descriptionGhostTabel, ObjectParameters ghostEvidenceParams)
    {
        _descriptionGhostTabel = descriptionGhostTabel;
        _ghostEvidenceParams = ghostEvidenceParams;
    }

    public ObjectParameters getGhostEvidenceParams()
    {
        return _ghostEvidenceParams;
    }

    public void SetPopUpDescriptionObject(DescriptionPopUpController popUp)
    {
        _descriptionPopUp = popUp;
    }

    public void ShowGhostInfo()
    {
          var localDescriptKey = _ghostName + nameof(Descript);
        _descriptionPopUp.SetDescriptionInfo(_descriptionGhostTabel, localDescriptKey);
        _descriptionPopUp.PopUpAppear();
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
