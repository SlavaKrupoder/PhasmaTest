using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

namespace CanvasAdapters
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridLayoutAdjuster : MonoBehaviour
    {
        [SF] private GridLayoutGroup _gridLayoutGroup;
        [SF] private Vector2 _referenceCellSize = new Vector2(190f, 46f);
        [SF] private Vector2 _referenceSpacingSize = new Vector2(6f, 9f);
        private readonly float ReferenceWidth = 480f;
        private readonly float ReferenceHeight = 800f;

        private void Start()
        {
            if (_gridLayoutGroup == null)
            {
                _gridLayoutGroup = GetComponent<GridLayoutGroup>();
            }
            AdjustGridLayout();
        }

        private void AdjustGridLayout()
        {


            float scaleX = Screen.width / ReferenceWidth;
            float scaleY = Screen.height / ReferenceHeight;

            float cellSizeX = (_referenceCellSize.x * scaleX);
            float cellSizeY = (_referenceCellSize.y * scaleY);

            float SpasingSizeX = (_referenceSpacingSize.x * scaleX);
            float SpasingSizeY = (_referenceSpacingSize.y * scaleY);

            _gridLayoutGroup.cellSize = new Vector2(cellSizeX, cellSizeY);
            // _gridLayoutGroup.spacing = new Vector2(SpasingSizeX, SpasingSizeY);
        }
    }
}


/// 87 19.17
/// 151 55