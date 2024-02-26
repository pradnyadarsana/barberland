using System;
using Barberland.Data.Entity;
using Barberland.Data.Repository;
using Barberland.Model;
using Barberland.Utility;
using Microsoft.Extensions.Logging;

namespace Barberland.Service
{
    public interface IBarbershopService
    {
        BarbershopIndexViewModel GetIndexDataModel(PaginationModel paginationModel, SearchModel? searchModel);
    }

    public class BarbershopService : IBarbershopService
	{
        private readonly ILogger<BarbershopService> _logger;
        private readonly IBarbershopRepository _barbershopRepository;

        public BarbershopService(ILogger<BarbershopService> logger, IBarbershopRepository barbershopRepository)
		{
			_logger = logger;
			_barbershopRepository = barbershopRepository;
		}

		public BarbershopIndexViewModel GetIndexDataModel(PaginationModel paginationModel, SearchModel? searchModel = null)
		{
			string mainHeaderBannerUrl = "../../img/carousel-1.jpeg";
			string headerText = "Test Header";
			string headerSubtitleText = "Text Subtitle test";

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
	}
}

