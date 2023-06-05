using System.Collections.Generic;
using UnityEngine;
using static GhostsEvidenceData;
using EvidenceEnum = GameLocalizationData.EvidenceLocalKey;
using SF = UnityEngine.SerializeField;

public class EvidenceChecker : MonoBehaviour
{
    private readonly int MaxEvidenceCount = 3; 
    private List<GameObject> _objectParametersList;
    [SF]private ObjectParameters _targetParameters = new ObjectParameters();

    private Dictionary<string, bool> _toggleStates = new Dictionary<string, bool>();
    private List<GameObject> _filteredParametersList;
    private int _previousParamCount = 0;

    public void OnToggleValueChanged(string paramName, bool isOn)
    {
        _toggleStates[paramName] = isOn;
        UpdateTargetParameters();
        FilterMatchingObjects();
    }

    private void UpdateTargetParameters()
    {
        _targetParameters.Emf = GetToggleState(EvidenceEnum.Emf.ToString());
        _targetParameters.Fingerprint = GetToggleState(EvidenceEnum.Fingerprint.ToString());
        _targetParameters.GhostWriting = GetToggleState(EvidenceEnum.GhostWriting.ToString());
        _targetParameters.FreezingTemperatures = GetToggleState(EvidenceEnum.FreezingTemperatures.ToString());
        _targetParameters.DOTSProjector = GetToggleState(EvidenceEnum.DOTSProjector.ToString());
        _targetParameters.GhostOrbs = GetToggleState(EvidenceEnum.GhostOrbs.ToString());
        _targetParameters.SpiritBox = GetToggleState(EvidenceEnum.SpiritBox.ToString());
    }

    private bool GetToggleState(string paramName)
    {
        return _toggleStates.ContainsKey(paramName) && _toggleStates[paramName];
    }

    private void FilterMatchingObjects()
    {
        _filteredParametersList.Clear();
        var currentParamCount = ParametersCount(_targetParameters);
        foreach (var objectParameter in _objectParametersList)
        {
            var ghostPointInfo = objectParameter.GetComponent<GhostTypePointInfo>();
            var currentParameters = ghostPointInfo.getGhostEvidenceParams();

            if (currentParamCount > 0 && currentParamCount <= MaxEvidenceCount)
            {
                if (AreParametersMatching(currentParameters, currentParamCount))
                {
                    _filteredParametersList.Add(objectParameter);
                    ghostPointInfo.UpdateGhostStatus(GhostStatus.WrightGhost);
                }
                else
                {
                    ghostPointInfo.UpdateGhostStatus(GhostStatus.WrongGhost);
                }
            }
            else
            {
                ghostPointInfo.UpdateGhostStatus(GhostStatus.UnActive);
            }
        }

        _previousParamCount = ParametersCount(_targetParameters);
    }

    public void SetObjectParamList(List<GameObject> objectParametersList)
    {
        _objectParametersList = objectParametersList;
        ResetEvidenceTable();
    }

    private void ResetEvidenceTable()
    {
        _filteredParametersList = new List<GameObject>(_objectParametersList);
    }

    private bool AreParametersMatching(ObjectParameters currentParameters, int currentParamCount)
    {
        int trueCount = 0;
        if (_targetParameters.Emf && currentParameters.Emf)
            trueCount++;
        if (_targetParameters.Fingerprint && currentParameters.Fingerprint)
            trueCount++;
        if (_targetParameters.GhostWriting && currentParameters.GhostWriting)
            trueCount++;
        if (_targetParameters.FreezingTemperatures && currentParameters.FreezingTemperatures)
            trueCount++;
        if (_targetParameters.DOTSProjector && currentParameters.DOTSProjector)
            trueCount++;
        if (_targetParameters.GhostOrbs && currentParameters.GhostOrbs)
            trueCount++;
        if (_targetParameters.SpiritBox && currentParameters.SpiritBox)
            trueCount++;

        return (trueCount >= currentParamCount && trueCount < MaxEvidenceCount || trueCount == MaxEvidenceCount);
    }

    private int ParametersCount(ObjectParameters parameters)
    {
        int trueCount = 0;

        if (parameters.Emf)
            trueCount++;
        if (parameters.Fingerprint)
            trueCount++;
        if (parameters.GhostWriting)
            trueCount++;
        if (parameters.FreezingTemperatures)
            trueCount++;
        if (parameters.DOTSProjector)
            trueCount++;
        if (parameters.GhostOrbs)
            trueCount++;
        if (parameters.SpiritBox)
            trueCount++;

        return trueCount;
    }
}