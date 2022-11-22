using UnityEngine;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference Listener of type `ObsTypePair`. Inherits from `AtomEventReferenceListener&lt;ObsTypePair, ObsTypePairEvent, ObsTypePairEventReference, ObsTypePairUnityEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-orange")]
    [AddComponentMenu("Unity Atoms/Listeners/ObsTypePair Event Reference Listener")]
    public sealed class ObsTypePairEventReferenceListener : AtomEventReferenceListener<
        ObsTypePair,
        ObsTypePairEvent,
        ObsTypePairEventReference,
        ObsTypePairUnityEvent>
    { }
}
