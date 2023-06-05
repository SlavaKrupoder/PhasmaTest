using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GhostsEvidenceData", menuName = "ScriptableObjects/GhostsEvidenceData", order = 1)]
public class GhostsEvidenceData : ScriptableObject
{
    [SerializeField]
    private List<ObjectParameters> _ghostsEvidenceDictionary = new List<ObjectParameters>();

    public ObjectParameters GetGhostParamByName(string ghostName)
    {
        var ghostsEvidenceDictionaryCount = _ghostsEvidenceDictionary.Count;
        ObjectParameters curParamData = null;
        for (var i = 0; i < ghostsEvidenceDictionaryCount; i++)
        {
            curParamData = _ghostsEvidenceDictionary[i];
            if (curParamData.GhostType == ghostName)
            {
                break;
            }
        }
        return curParamData;
    }

    [System.Serializable]
    public class ObjectParameters
    {
        public string GhostType = "";
        public bool Emf = false;
        public bool Fingerprint = false;
        public bool GhostWriting = false;
        public bool FreezingTemperatures = false;
        public bool DOTSProjector = false;
        public bool GhostOrbs = false;
        public bool SpiritBox = false;
    }
}
