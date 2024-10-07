using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    [RequireComponent(requiredComponent: typeof(GridLayoutGroup), requiredComponent2: typeof(RectTransform))]
    public class GridLayoutWidthEnforcer : MonoBehaviour
    {
        private GridLayoutGroup _gridLayout;
        private RectTransform _rectTransform;

        private float _maxSpacing;
        private int _childCount;

        private void Awake()
        {
            _gridLayout = GetComponent<GridLayoutGroup>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Start()
        {
            _maxSpacing = _gridLayout.spacing.x;
            _childCount = transform.childCount;
        }

        private void Update()
        {
            var corners = new Vector3[4];
            _rectTransform.GetWorldCorners(corners);
            float min = Mathf.Infinity;
            float max = Mathf.NegativeInfinity;
            foreach (Vector3 corner in corners)
            {
                if (corner.x > max) max = corner.x;
                if (corner.x < min) min = corner.x;
            }

            float width = max - min;

            int count = _gridLayout.transform.childCount;
            float elementWidth = _gridLayout.cellSize.x;
            float totalWidth = count * elementWidth;

            float spacing = (width - totalWidth) / (count - 1);
            spacing = Mathf.Min(a: spacing, b: _maxSpacing);

            _gridLayout.spacing = new Vector2(x: spacing, y: _gridLayout.spacing.y);
        }
    }
}
