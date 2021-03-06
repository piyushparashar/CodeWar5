﻿using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.SourceEngine.Modules.Model
{
    internal class EmptyMapEnity : DataBoundMapEntity
    {
        public EmptyMapEnity()
        {
            IsMoveAllowedOnThis = true;
        }
        public override Image Icon => null;

        public override string DisplayText => "";

        public override string Description => "";

        public override int ScoringWeight => 0;

        public override MapEntityMultiplicity Multiplicity { get => MapEntityMultiplicity.Multiple ; set => throw new System.NotImplementedException(); }
    }
}
