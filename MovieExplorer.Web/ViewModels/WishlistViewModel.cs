namespace MovieExplorer.Web.ViewModels;

public class WishlistViewModel
{
    public IReadOnlyCollection<WishlistItemViewModel> Movies { get; set; } = [];
}