using System.Windows.Controls;
using WhiteWalkersGames.SourceEngine.Modules.Common;

namespace WhiteWalkersGames.SourceEngine.Modules.Model
{
    internal class DataBoundMapEntity : IMapEntity
    {
        internal DataBoundMapEntity()
        {

        }

        protected internal DataBoundMapEntity(IMapEntity mapEntity)
        {
            Icon = mapEntity.Icon;
            DisplayText = mapEntity.DisplayText;
            Description = mapEntity.Description;
            ScoringWeight = mapEntity.ScoringWeight;
            Multiplicity = mapEntity.Multiplicity;
            DistributionWeight = mapEntity.DistributionWeight;
            IsMoveAllowedOnThis = mapEntity.IsMoveAllowedOnThis;
            IsActive = true;
        }

        public virtual bool IsActive { get; set; }
       
        public virtual Image Icon { get; set; }

        public virtual string DisplayText { get; set; }

        public virtual string Description { get; set; }

        public virtual int ScoringWeight { get; set; }

        public virtual MapEntityMultiplicity Multiplicity { get; set; }

        public virtual ushort DistributionWeight { get; set; }

        public virtual bool IsMoveAllowedOnThis { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
