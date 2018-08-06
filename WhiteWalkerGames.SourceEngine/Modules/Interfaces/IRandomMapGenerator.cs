using System.Collections.Generic;
using System.Collections.ObjectModel;
using WhiteWalkersGames.SourceEngine.Modules.Common;
using WhiteWalkersGames.SourceEngine.Modules.Model;

namespace WhiteWalkersGames.SourceEngine.Modules.Interfaces
{
    internal interface IRandomMapGenerator
    {
        ObservableCollection<ObservableCollection<DataBoundMapEntity>> GenerateMap(List<IMapEntity> mapEntities, int totalRows, int totalColumns);
    }
}
