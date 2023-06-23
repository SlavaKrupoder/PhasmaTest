using TMPro;
using UnityEngine;
using SF = UnityEngine.SerializeField;

namespace PageLogic
{
    public class Page : MonoBehaviour
    {
        [SF] private GameObject _evidanceCheckBlock;
        [SF] private GameObject _ghostTypeBlock;
        [SF] private TextMeshProUGUI _EvidanceTextLabel;
    }
}