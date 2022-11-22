using System;
using UnityAtoms.BaseAtoms;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `ObsType`. Inherits from `AtomReference&lt;ObsType, ObsTypePair, ObsTypeConstant, ObsTypeVariable, ObsTypeEvent, ObsTypePairEvent, ObsTypeObsTypeFunction, ObsTypeVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ObsTypeReference : AtomReference<
        ObsType,
        ObsTypePair,
        ObsTypeConstant,
        ObsTypeVariable,
        ObsTypeEvent,
        ObsTypePairEvent,
        ObsTypeObsTypeFunction,
        ObsTypeVariableInstancer>, IEquatable<ObsTypeReference>
    {
        public ObsTypeReference() : base() { }
        public ObsTypeReference(ObsType value) : base(value) { }
        public bool Equals(ObsTypeReference other) { return base.Equals(other); }
        protected override bool ValueEquals(ObsType other)
        {
            throw new NotImplementedException();
        }
    }
}
