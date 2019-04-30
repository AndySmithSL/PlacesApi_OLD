using PlacesApi.Views.Base;

namespace PlacesApi.Views.ListView
{
    public class ContinentListView : ContinentView
    {
        public new string Parent => ViewObject.Parent?.Name;
    }
}
