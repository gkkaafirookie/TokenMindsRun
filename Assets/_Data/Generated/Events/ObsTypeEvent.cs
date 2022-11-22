using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `ObsType`. Inherits from `AtomEvent&lt;ObsType&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/ObsType", fileName = "ObsTypeEvent")]
    public sealed class ObsTypeEvent : AtomEvent<ObsType>
    {
    }
}
