using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Value List of type `ObsType`. Inherits from `AtomValueList&lt;ObsType, ObsTypeEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-piglet")]
    [CreateAssetMenu(menuName = "Unity Atoms/Value Lists/ObsType", fileName = "ObsTypeValueList")]
    public sealed class ObsTypeValueList : AtomValueList<ObsType, ObsTypeEvent> { }
}
