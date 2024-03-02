using System;
using Barberland.Data.Entity;
using Barberland.Data.Repository;
using Barberland.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Barberland.Service
{
	public interface IServiceCategoryService
	{
        ResponseModel<ServiceCategoryDetailViewModel> GetServiceDetailDataModel(string barbershopServicePermalink);
    }

	public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly ILogger<BarbershopService> _logger;
        private readonly IBarbershopRepository _barbershopRepository;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceCategoryImageRepository _serviceCategoryImageRepository;

        public ServiceCategoryService(ILogger<BarbershopService> logger, IBarbershopRepository barbershopRepository, IServiceCategoryRepository serviceCategoryRepository, IServiceCategoryImageRepository serviceCategoryImageRepository)
        {
            _logger = logger;
            _barbershopRepository = barbershopRepository;
            _serviceCategoryRepository = serviceCategoryRepository;
            _serviceCategoryImageRepository = serviceCategoryImageRepository;
        }

        public ResponseModel<ServiceCategoryDetailViewModel> GetServiceDetailDataModel(string barbershopServicePermalink)
        {
            ResponseModel<ServiceCategoryDetailViewModel> responseModel = new();

            ServiceCategory? serviceCategory = _serviceCategoryRepository.GetByPermalink(barbershopServicePermalink);
            if(serviceCategory == null)
            {
                responseModel.StatusCode = StatusCodes.Status404NotFound;
                responseModel.Message = "Service Category not found with permalink '"+ barbershopServicePermalink + "'";
                return responseModel;
            }

            ServiceCategoryDetailViewModel viewModel = new();
            viewModel.ServiceCategory = serviceCategory;

            List<ServiceCategoryImage> serviceCategoryImages = _serviceCategoryImageRepository.GetByServiceCategoryId(serviceCategory.Id).ToList();
            viewModel.ServiceCategoryImages = serviceCategoryImages;

            Barbershop? barbershop = _barbershopRepository.Find(serviceCategory.BarbershopId);
            viewModel.Barbershop = barbershop;

            responseModel.Object = viewModel;
            return responseModel;
        }
	}
}

