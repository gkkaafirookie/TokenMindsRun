using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `ObsType`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(ObsTypeVariable))]
    public sealed class ObsTypeVariableEditor : AtomVariableEditor<ObsType, ObsTypePair> { }
}
