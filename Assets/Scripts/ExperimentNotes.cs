using UnityEngine;
using UnityEngine.UI;

namespace GodsExperiment
{
    public class ExperimentNotes : MonoBehaviour
    {
        [SerializeField] private Transform NotesCard;
        [SerializeField] private Button ShowHideButton;

        [SerializeField] private Vector2 OffscreenPoint;
        [SerializeField] private Vector2 OnscreenPoint;
    }
}
