using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ObsType`. Inherits from `AtomEventReferenceListener&lt;ObsType, ObsTypeEvent, ObsTypeEventReference, ObsTypeUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ObsType Event Reference Listener")]
    public sealed class ObsTypeEventReferenceListener : AtomEventReferenceListener<
        ObsType,
        ObsTypeEvent,
        ObsTypeEventReference,
        ObsTypeUnityEvent>
    { }
}
