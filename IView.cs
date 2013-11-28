namespace GitHubClientWinForm
{
    public interface IView<TModel>
    {
        TModel Model { get; set; }
    }
}