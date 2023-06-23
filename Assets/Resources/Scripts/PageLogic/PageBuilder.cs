using PoolSpace;
using PopUps;
using System;
using System.Collections.Generic;
using UnityEngine;
using EvidenceEnum = GameLocalizationData.EvidenceLocalKey;
using GhostsEnum = GameLocalizationData.GhostTypeLocalKey;
using SF = UnityEngine.SerializeField;

namespace PageLogic
{
    public class PageBuilder : MonoBehaviour
    {
        private const string Label = "Label";
        private const string EvidencesLocalizationTable = "Evidences Localization Table";
        private const string GhostTypeTable = "Ghost Type Table";
        private const string GhostsDescriptionTabel = "Ghosts Description Tabel";
        [SF] private Transform _evidenceBoxParentTransform;
        [SF] private Transform _ghostBoxParentTransform;
        [SF] private ObjectPool _evidencesPool;
        [SF] private ObjectPool _ghostsPool;
        [SF] private GhostsEvidenceData _ghostsEvidenceData;
        [SF] private EvidenceChecker _evidenceChecker;
        [SF] private DescriptionPopUpController _descriptionPopUp;
        private List<GameObject> _ghostModelsStackForPool = new();
        private int _evidenceTotalCount;
        private int _ghostsTotalCount;

        private void Start()
        {
            _evidenceTotalCount = Enum.GetNames(typeof(EvidenceEnum)).Length;
            _ghostsTotalCount = Enum.GetNames(typeof(GhostsEnum)).Length;

            _evidencesPool.InitPool(_evidenceTotalCount);
            _ghostsPool.InitPool(_ghostsTotalCount);

            InitElements(_evidenceBoxParentTransform, _evidencesPool, _evidenceTotalCount, EvidencesLocalizationTable, typeof(EvidenceEnum));
            InitElements(_ghostBoxParentTransform, _ghostsPool, _ghostsTotalCount, GhostTypeTable, typeof(GhostsEnum));

            _evidenceChecker.SetObjectParamList(_ghostModelsStackForPool);
        }

        private void InitElements(Transform parentTransform, ObjectPool pool, int totalCount, string localizationTable, Type enumType)
        {
            for (var i = 0; i < totalCount; i++)
            {
                var poolItem = pool.GetPoolElement();
                poolItem.transform.SetParent(parentTransform);
                string enumCurrFieldName = Enum.GetName(enumType, i);
                poolItem.name = enumCurrFieldName;

                if (parentTransform == _evidenceBoxParentTransform)
                {
                    var evidanceComponent = poolItem.GetComponent<EvidenceType>();
                    string evidenceLocalkey = (enumCurrFieldName + nameof(Label));
                    evidanceComponent.SetEvidenceInfo(localizationTable, evidenceLocalkey);
                }
                else if (parentTransform == _ghostBoxParentTransform)
                {
                    var ghostEvidenceData = _ghostsEvidenceData.GetGhostParamByName(enumCurrFieldName);
                    var ghostComponent = poolItem.GetComponent<GhostTypePointInfo>();
                    ghostComponent.SetLocalizeGhostInfo(GhostTypeTable, enumCurrFieldName, nameof(Label));
                    ghostComponent.SetGhosDescriptionInfo(GhostsDescriptionTabel, ghostEvidenceData);
                    ghostComponent.SetPopUpDescription(_descriptionPopUp);
                    _ghostModelsStackForPool.Add(poolItem);
                }
            }
        }
    }
}