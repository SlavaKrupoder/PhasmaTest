using UnityEngine;

[CreateAssetMenu(fileName = "GameLocalizationData", menuName = "ScriptableObjects/GameLocalizationDataObject", order = 1)]
public class GameLocalizationData : ScriptableObject
{
    public enum GhostTypeLocalKey
    {
        Spirit = 0,
        Wraith,
        Phantom,
        Poltergeist,
        Banshee,
        Jinn,
        Mare,
        Revenant,
        Shade,
        Demon,
        Yurei,
        Oni,
        Yokai,
        Hantu,
        Goryo,
        Myling,
        Onryo,
        TheTwins,
        Raiju,
        Obake,
        TheMimic,
        Moroi,
        Deogen,
        Thaye,
    }

    public enum EvidenceLocalKey
    {
        Emf = 0,
        DOTSProjector,
        Fingerprint,
        GhostOrbs,
        GhostWriting,
        SpiritBox,
        FreezingTemperatures,
    }
}

