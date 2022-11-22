using UnityEngine;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Set variable value Action of type `ObsType`. Inherits from `SetVariableValue&lt;ObsType, ObsTypePair, ObsTypeVariable, ObsTypeConstant, ObsTypeReference, ObsTypeEvent, ObsTypePairEvent, ObsTypeVariableInstancer&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-purple")]
    [CreateAssetMenu(menuName = "Unity Atoms/Actions/Set Variable Value/ObsType", fileName = "SetObsTypeVariableValue")]
    public sealed class SetObsTypeVariableValue : SetVariableValue<
        ObsType,
        ObsTypePair,
        ObsTypeVariable,
        ObsTypeConstant,
        ObsTypeReference,
        ObsTypeEvent,
        ObsTypePairEvent,
        ObsTypeObsTypeFunction,
        ObsTypeVariableInstancer>
    { }
}
