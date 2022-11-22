using UnityEngine;
using System;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `ObsType`. Inherits from `AtomVariable&lt;ObsType, ObsTypePair, ObsTypeEvent, ObsTypePairEvent, ObsTypeObsTypeFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/ObsType", fileName = "ObsTypeVariable")]
    public sealed class ObsTypeVariable : AtomVariable<ObsType, ObsTypePair, ObsTypeEvent, ObsTypePairEvent, ObsTypeObsTypeFunction>
    {
        protected override bool ValueEquals(ObsType other)
        {
            throw new NotImplementedException();
        }
    }
}
