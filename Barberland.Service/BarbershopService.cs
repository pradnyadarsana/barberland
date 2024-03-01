using System;
using Barberland.Data.Entity;
using Barberland.Data.Repository;
using Barberland.Model;
using Barberland.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Barberland.Service
{
    public interface IBarbershopService
    {
        BarbershopIndexViewModel GetIndexDataModel(PaginationModel paginationModel, SearchModel? searchModel);
		ResponseModel<BarbershopDetailViewModel> GetBarbershopDetail(string barbershopPermalink, PaginationModel servicePaginationModel);
    }

    public class BarbershopService : IBarbershopService
	{
        private readonly ILogger<BarbershopService> _logger;
        private readonly AppSettings _configs;
        private readonly IBarbershopRepository _barbershopRepository;
        private readonly IServiceCategoryRepository _serviceCategoryRepository;
        private readonly IServiceCategoryImageRepository _serviceCategoryImageRepository;

        public BarbershopService(ILogger<BarbershopService> logger, IOptions<AppSettings> configuration, IBarbershopRepository barbershopRepository, IServiceCategoryRepository serviceCategoryRepository, IServiceCategoryImageRepository serviceCategoryImageRepository)
		{
			_logger = logger;
            _configs = configuration.Value;
            _barbershopRepository = barbershopRepository;
			_serviceCategoryRepository = serviceCategoryRepository;
			_serviceCategoryImageRepository = serviceCategoryImageRepository;

        }

		public BarbershopIndexViewModel GetIndexDataModel(PaginationModel paginationModel, SearchModel? searchModel = null)
		{
			string mainHeaderBannerUrl = "../../img/carousel-1.jpeg";
			string headerText = "BARBERSHOPS";
			string headerSubtitleText = "serving the best for you.";

			IQueryable<Barbershop> barbershops = _barbershopRepository.GetAll().Where(x => !x.IsDeleted).OrderBy(x => x.Name);

			if (searchModel != null)
			{
				if (!string.IsNullOrEmpty(searchModel.SearchText))
				{
					barbershops = barbershops.Where(x => x.Name.ToLower().Contains(searchModel.SearchText.ToLower()));
				}
				if (searchModel.OrderBy == "name-asc")
				{
					barbershops = barbershops.OrderBy(x => x.Name);
				}
				else if (searchModel.OrderBy == "name-desc")
				{
					barbershops = barbershops.OrderByDescending(x => x.Name);
				}
				else if (searchModel.OrderBy == "newest")
				{
					barbershops = barbershops.OrderByDescending(x => x.CreatedDate);
				}
			}

            #region Data Pagination
            List<Barbershop> barbershopList = GlobalFunction.PopulateDataPaging<Barbershop>(barbershops, paginationModel.PageNumber, paginationModel.DataPerPage, out int totalPages).ToList();
			#endregion

			BarbershopIndexViewModel viewModel = new();
            viewModel.MainHeaderBannerUrl = mainHeaderBannerUrl;
            viewModel.HeaderTitleText = headerText;
			viewModel.HeaderSubtitleText = headerSubtitleText;

            viewModel.Barbershops = barbershopList;

            viewModel.PageNumber = paginationModel.PageNumber > totalPages ? 1 : paginationModel.PageNumber; //fixing page number
			viewModel.DataPerPage = paginationModel.DataPerPage;
			viewModel.TotalPages = totalPages;

            return viewModel;
		}

		public ResponseModel<BarbershopDetailViewModel> GetBarbershopDetail(string barbershopPermalink, PaginationModel servicePaginationModel)
		{
			ResponseModel<BarbershopDetailViewModel> responseModel = new ResponseModel<BarbershopDetailViewModel>();
			Barbershop? barbershop = _barbershopRepository.GetByPermalink(barbershopPermalink);

			if(barbershop == null)
			{
				responseModel.StatusCode = StatusCodes.Status404NotFound;
				responseModel.Message = "Barbershop not found";
				return responseModel;
            }

            BarbershopDetailViewModel viewModel = new BarbershopDetailViewModel();
			viewModel.Barbershop = barbershop;

			#region Populate Data Service Category
			List<ServiceCategory> serviceCategories = GlobalFunction.PopulateDataPaging<ServiceCategory>(_serviceCategoryRepository.GetByBarbershopId(barbershop.Id), servicePaginationModel.PageNumber, servicePaginationModel.DataPerPage, out int totalPages).ToList();

			viewModel.ServiceCategories = new List<ServiceCategoryIndexModel>();
			foreach (var service in serviceCategories)
			{
				ServiceCategoryImage? serviceImgThumbnail = _serviceCategoryImageRepository.GetByServiceCategoryId(service.Id).FirstOrDefault(x => x.IsThumbnail);

				ServiceCategoryIndexModel serviceModel = new ServiceCategoryIndexModel()
				{
					Name = service.Name,
					BarbershopName = barbershop != null ? barbershop.Name : "",
					ImgThumbnailUrl = serviceImgThumbnail != null ? serviceImgThumbnail.ImageUrl : _configs.URLSettings.NoImageThumbnailURL,
					Permalink = service.Permalink,
					Price = service.Price
				};

				viewModel.ServiceCategories.Add(serviceModel);
			}

            viewModel.ServicePageNumber = servicePaginationModel.PageNumber > totalPages ? 1 : servicePaginationModel.PageNumber; //fixing page number
            viewModel.ServiceDataPerPage = servicePaginationModel.DataPerPage;
            viewModel.ServiceTotalPages = totalPages;
			#endregion

			viewModel.GoogleAPIKey = _configs.GoogleServices.GoogleAPIKey;

            responseModel.Object = viewModel;
			return responseModel;
        }
	}
}

