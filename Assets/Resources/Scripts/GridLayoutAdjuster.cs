using UnityEngine;
using UnityEngine.UI;
using SF = UnityEngine.SerializeField;

[RequireComponent(typeof(GridLayoutGroup))]
public class GridLayoutAdjuster : MonoBehaviour
{
    [SF] private GridLayoutGroup _gridLayoutGroup;
    [SF] private Vector2 _referenceCellSize = new Vector2(190f, 46f);
    [SF] private Vector2 _referenceSpacingSize = new Vector2(6f, 9f);

    private void Start()
    {
        if(_gridLayoutGroup == null)
        {
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }
        AdjustGridLayout();
    }

    private void AdjustGridLayout()
    {
        float aspectRatio = (float)Screen.width / Screen.height;

        float referenceWidth = 480f;
        float referenceHeight = 800;

        float scaleX = Screen.width / referenceWidth;
        float scaleY = Screen.height / referenceHeight;

        float cellSizeX = (_referenceCellSize.x * scaleX);
        float cellSizeY = (_referenceCellSize.y * scaleY);

       // float SpasingSizeX = (_referenceSpacingSize.x / scaleX);
        // float SpasingSizeY = (_referenceSpacingSize.y / scaleY);

        _gridLayoutGroup.cellSize = new Vector2(cellSizeX, cellSizeY);
       // _gridLayoutGroup.spacing = new Vector2(SpasingSizeX, SpasingSizeY);
    }
}
