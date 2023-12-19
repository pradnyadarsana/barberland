using Barberland.Data.Entity;

namespace Barberland.Model;

public class HomeIndexViewModel
{
    public string HeaderTitleText { get; set; }
    public string HeaderSubtitleText { get; set; }
    //public List<Banner> MainCarouselBanners { get; set; }
    public List<ServiceCategoryIndexModel> ServiceCategories { get; set; }
    public string ServiceDescription { get; set; }
    public List<Barbershop> Barbershops { get; set; }
    public string BarbershopDescription { get; set; }
    //public Banner GalleryBanner { get; set; }
    //public SearchModel SearchModel { get; set; }
}

public class ServiceCategoryIndexModel
{
    public string Name { get; set; }
    public string BarbershopName { get; set; }
    public string ImgThumbnailUrl { get; set; }
    public decimal Price { get; set; }
    public string Permalink { get; set; }

}

