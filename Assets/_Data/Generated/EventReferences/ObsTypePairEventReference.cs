using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `ObsTypePair`. Inherits from `AtomEventReference&lt;ObsTypePair, ObsTypeVariable, ObsTypePairEvent, ObsTypeVariableInstancer, ObsTypePairEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ObsTypePairEventReference : AtomEventReference<
        ObsTypePair,
        ObsTypeVariable,
        ObsTypePairEvent,
        ObsTypeVariableInstancer,
        ObsTypePairEventInstancer>, IGetEvent 
    { }
}
