using Newtonsoft.Json;
using PlacesApi.Code.Classes;
using PlacesApi.Models;

namespace PlacesApi.Views.Base
{
    public class ContinentView : View<Continent>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public string Code => ViewObject.Code;
        public int? ParentId => ViewObject.ParentId;
       
        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ContinentView Parent => GetView<ContinentView, Continent>(ViewObject.Parent);

        #endregion Foreign Properties

        #region Other Properties

        //public string StartLabel => CommonFunctions.GetDateLabel(Start);
        //public string EndLabel => CommonFunctions.GetDateLabel(End);

        //[JsonIgnore]
        //public DateTime AbsoluteStart => Start.HasValue ? Start.Value : DateTime.MinValue;

        //[JsonIgnore]
        //public DateTime AbsoluteEnd => End.HasValue ? End.Value : DateTime.MaxValue;

        public override string ListName => Name + ":" + Code;

        #endregion Other Properties
    }
}
