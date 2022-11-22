#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ObsType`. Inherits from `AtomEventEditor&lt;ObsType, ObsTypeEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ObsTypeEvent))]
    public sealed class ObsTypeEventEditor : AtomEventEditor<ObsType, ObsTypeEvent> { }
}
#endif
