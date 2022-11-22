#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ObsTypePair`. Inherits from `AtomDrawer&lt;ObsTypePairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ObsTypePairEvent))]
    public class ObsTypePairEventDrawer : AtomDrawer<ObsTypePairEvent> { }
}
#endif
