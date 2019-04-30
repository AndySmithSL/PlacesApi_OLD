using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlacesApi.Code.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacesApi.Context;
using PlacesApi.Models;
using PlacesApi.Views.ListView;
using PlacesApi.Views.ItemView;
using PlacesApi.Data;
using Microsoft.EntityFrameworkCore;

namespace PlacesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : BaseController<Continent, TravelContext>
    {
        #region Constructor

        public ContinentController(TravelContext context)
            : base(context) { }

        #endregion Constructor

        #region API

        [HttpGet]
        public async Task<IEnumerable<ContinentListView>> GetItems()
        {
            return await GetViewsAsync<ContinentListView>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {

            return await GetViewAsync<ContinentItemView>(id);
        }

        #endregion API

        #region Override Abstract Methods

        protected override DataAccess<Continent> LoadDataAccess()
        {
            return new DataAccess<Continent>(Context, Context.Continent);
        }

        protected override Func<int, Continent> GetItemFunction()
        {
            return id => Context
                        .Continent
                        .Include(x => x.Parent)
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override Func<IEnumerable<Continent>> GetItemsFunction()
        {
            return () => Context
                        .Continent
                        .Include(x => x.Parent)
                        .AsEnumerable();
        }

        protected override Func<Continent, bool> GetExistsFunc(int id)
        {
            return x => x.Id == id;
        }

        #endregion Override Abstract Methods
    }
}