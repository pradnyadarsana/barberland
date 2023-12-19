using Barberland.Data.Entity;
using System.Collections.Generic;
using Barberland.Data.Repository;
using Microsoft.Extensions.Logging;
using Barberland.Model;

namespace Barberland.Service;

public interface IHomePageService
{
    HomeIndexViewModel GetIndexDataModel();
}

public class HomePageService : IHomePageService
{
    private readonly ILogger<HomePageService> _logger;
    private readonly IServiceCategoryRepository _serviceCategoryRepository;
    private readonly IServiceCategoryImageRepository _serviceCategoryImageRepository;
    private readonly IBarbershopRepository _barbershopRepository;

    public HomePageService(ILogger<HomePageService> logger, IServiceCategoryRepository serviceCategoryRepository, IServiceCategoryImageRepository serviceCategoryImageRepository, IBarbershopRepository barbershopRepository)
    {
        _logger = logger;
        _serviceCategoryRepository = serviceCategoryRepository;
        _barbershopRepository = barbershopRepository;
        _serviceCategoryImageRepository = serviceCategoryImageRepository;
    }
    
    public HomeIndexViewModel GetIndexDataModel()
    {
        HomeIndexViewModel viewModel = new();
        viewModel.HeaderTitleText = "Barberland";
        viewModel.HeaderSubtitleText = "No more wasting time in your favorite barbershop.";

        List<ServiceCategoryIndexModel> serviceCategoryModels = new List<ServiceCategoryIndexModel>();
        List<ServiceCategory> serviceCategories = _serviceCategoryRepository.GetAll().Where(x => !x.IsDeleted).Take(4).ToList();
        foreach (ServiceCategory service in serviceCategories)
        {
            Barbershop? barbershop = _barbershopRepository.Find(service.BarbershopId);
            ServiceCategoryImage? serviceImgThumbnail = _serviceCategoryImageRepository.GetByServiceCategoryId(service.Id).FirstOrDefault(x => x.IsThumbnail);

            ServiceCategoryIndexModel serviceModel = new ServiceCategoryIndexModel()
            {
                Name = service.Name,
                BarbershopName = barbershop != null ? barbershop.Name : "",
                ImgThumbnailUrl = serviceImgThumbnail != null ? serviceImgThumbnail.ImageUrl : "~/img/no-image-default.jpeg",
                Permalink = service.Permalink,
                Price = service.Price
            };
            serviceCategoryModels.Add(serviceModel);
        }

        viewModel.ServiceCategories = serviceCategoryModels;
        viewModel.ServiceDescription = "All good for you.";

        List<Barbershop> barbershops = _barbershopRepository.GetAll().Where(x => !x.IsDeleted).Take(4).ToList();
        viewModel.Barbershops = barbershops;
        viewModel.BarbershopDescription = "Try if you wanna become a handsome man.";

        return viewModel;
    }

}


