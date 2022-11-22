#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ObsTypePair`. Inherits from `AtomEventEditor&lt;ObsTypePair, ObsTypePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ObsTypePairEvent))]
    public sealed class ObsTypePairEventEditor : AtomEventEditor<ObsTypePair, ObsTypePairEvent> { }
}
#endif
