using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `ObsType`. Inherits from `AtomVariableInstancer&lt;ObsTypeVariable, ObsTypePair, ObsType, ObsTypeEvent, ObsTypePairEvent, ObsTypeObsTypeFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/ObsType Variable Instancer")]
    public class ObsTypeVariableInstancer : AtomVariableInstancer<
        ObsTypeVariable,
        ObsTypePair,
        ObsType,
        ObsTypeEvent,
        ObsTypePairEvent,
        ObsTypeObsTypeFunction>
    { }
}
