using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class GridShrinker : MonoBehaviour
    {
        [SerializeField] private RectTransform RectTransform;
        [SerializeField] private GridLayoutGroup Grid;
        [SerializeField] private float MaxHeight;
        private readonly Vector3[] _corners = new Vector3[4];

        private void Update()
        {
            RectTransform.GetWorldCorners(_corners);

            float minY = Mathf.Infinity;
            float maxY = Mathf.NegativeInfinity;
            foreach (Vector3 corner in _corners)
            {
                minY = Mathf.Min(a: minY, b: corner.y);
                maxY = Mathf.Max(a: maxY, b: corner.y);
            }

            if (maxY - minY > MaxHeight)
            {
                Debug.Log($"height: {maxY - minY}");
                Vector2 currentSpacing = Grid.spacing;
                // if this ain't enough we'll do it again in the next frame
                Grid.spacing = new Vector2(x: currentSpacing.x, y: currentSpacing.y - 0.1f);
            }
        }
    }
}
