﻿namespace EventSystem.Web.Areas.EventMaker.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Base;
    using EventSystem.Models;
    using Infrastructure.Populators;
    using Models.Places;
    using Services.Contracts;

    public class PlacesController : BaseEventMakerController<PlaceViewModel>
    {
        private IPlacesService placesService;

        private IImagesService imagesService;

        public PlacesController(IPlacesService placesService, IImagesService imagesService)
        {
            this.placesService = placesService;
            this.imagesService = imagesService;
        }

        [HttpGet]
        [PopulateCities]
        [PopulateCountries]
        public ActionResult Create()
        {
            var model = this.GetModel<PostPlaceViewModel, Place>(this.placesService, null);

            return this.View(model);
        }

        [HttpGet]
        [PopulateCities]
        [PopulateCountries]
        public ActionResult Edit(int id)
        {
            var model = this.GetModel<PostPlaceViewModel, Place>(this.placesService, id);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Create(PostPlaceViewModel model)
        {
            this.imagesService.SaveImages(model.Files);
            return this.RedirectToAction("Details");
        }

        public ActionResult Detatils(int id)
        {
            return this.View();
        }

        protected override IQueryable<TModel> GetData<TModel>(int count, int page)
        {
            return this.placesService
                .GetAll()
                 .ProjectTo<PlaceViewModel>(this.Config) as IQueryable<TModel>;
        }
    }
}
