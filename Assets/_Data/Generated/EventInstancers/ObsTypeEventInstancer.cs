using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `ObsType`. Inherits from `AtomEventInstancer&lt;ObsType, ObsTypeEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/ObsType Event Instancer")]
    public class ObsTypeEventInstancer : AtomEventInstancer<ObsType, ObsTypeEvent> { }
}
