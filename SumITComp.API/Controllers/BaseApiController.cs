using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SumITComp.API.Models;

namespace SumITComp.API.Controllers
{
    public abstract class BaseApiController : ApiController
    {


        IRepository _repo;
        ModelFactory _modelFactory;

        public BaseApiController(IRepository repository)
        {
            _repo = repository;

        }

        protected IRepository TheRepository
        {
            get
            {
                return _repo;
                
            }
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request,TheRepository);
                }
                return _modelFactory;
            }
        }




    }
}