#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Value List property drawer of type `ObsType`. Inherits from `AtomDrawer&lt;ObsTypeValueList&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ObsTypeValueList))]
    public class ObsTypeValueListDrawer : AtomDrawer<ObsTypeValueList> { }
}
#endif
