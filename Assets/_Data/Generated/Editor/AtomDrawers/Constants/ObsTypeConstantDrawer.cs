#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `ObsType`. Inherits from `AtomDrawer&lt;ObsTypeConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(ObsTypeConstant))]
    public class ObsTypeConstantDrawer : VariableDrawer<ObsTypeConstant> { }
}
#endif
