using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `ObsTypePair`. Inherits from `AtomEvent&lt;ObsTypePair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ObsTypePair", fileName = "ObsTypePairEvent")]
    public sealed class ObsTypePairEvent : AtomEvent<ObsTypePair>
    {
    }
}
