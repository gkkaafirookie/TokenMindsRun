using System;
using UnityEngine.Events;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// None generic Unity Event of type `ObsType`. Inherits from `UnityEvent&lt;ObsType&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ObsTypeUnityEvent : UnityEvent<ObsType> { }
}
