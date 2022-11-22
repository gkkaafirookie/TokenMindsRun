using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `ObsType`. Inherits from `AtomEventReference&lt;ObsType, ObsTypeVariable, ObsTypeEvent, ObsTypeVariableInstancer, ObsTypeEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ObsTypeEventReference : AtomEventReference<
        ObsType,
        ObsTypeVariable,
        ObsTypeEvent,
        ObsTypeVariableInstancer,
        ObsTypeEventInstancer>, IGetEvent 
    { }
}
