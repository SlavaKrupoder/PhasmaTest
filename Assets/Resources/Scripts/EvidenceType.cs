using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

[RequireComponent(typeof(LocalizeStringEvent), typeof(Toggle))]
public class EvidenceType : MonoBehaviour
{
    private LocalizeStringEvent _locStringEvent;
    private string _nameEvidence;
    private Toggle _toggle;

    public void SetEvidenceInfo(string evidenceTabelName, string nameEvidence)
    {
        _nameEvidence = this.name;
        _locStringEvent = GetComponent<LocalizeStringEvent>();
        _toggle = GetComponent<Toggle>();
        _locStringEvent.SetTable(evidenceTabelName);
        _locStringEvent.SetEntry(nameEvidence);
        _locStringEvent.RefreshString();
        _toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        if (_toggle != null)
        {
            EvidenceChecker evidenceChecker = FindObjectOfType<EvidenceChecker>();
            if (evidenceChecker != null)
            {
                evidenceChecker.OnToggleValueChanged(_nameEvidence, isOn);
            }
        }
    }
}
