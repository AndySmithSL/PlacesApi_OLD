namespace PlacesApi.Code.Interfaces
{
    public interface IView<TObject>
    {
        TObject ViewObject { get; set; }
    }
}
