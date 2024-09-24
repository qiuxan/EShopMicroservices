namespace Shopping.Web.Pages;
public class IndexModel
    (ICatalogService catalogService, ILogger<IndexModel> logger)
    : PageModel
{

    public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();


    public async Task<IActionResult> OnGetAsync()
    {
        logger.LogInformation("Index page requested");
        var result = await catalogService.GetProducts();
        //var result = await catalogService.GetProducts(2,3);
        ProductList = result.Products;
        return Page();
    }
}
