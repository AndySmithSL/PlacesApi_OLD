using PlacesApi.Models;
using PlacesApi.Views.Base;

namespace PlacesApi.Views.ItemView
{
    public class ContinentItemView : ContinentView
    {
        public new ContinentItemView Parent => GetView<ContinentItemView, Continent>(ViewObject.Parent);
    }
}
