using System;
using UnityEngine;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;ObsType&gt;`. Inherits from `IPair&lt;ObsType&gt;`.
    /// </summary>
    [Serializable]
    public struct ObsTypePair : IPair<ObsType>
    {
        public ObsType Item1 { get => _item1; set => _item1 = value; }
        public ObsType Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private ObsType _item1;
        [SerializeField]
        private ObsType _item2;

        public void Deconstruct(out ObsType item1, out ObsType item2) { item1 = Item1; item2 = Item2; }
    }
}