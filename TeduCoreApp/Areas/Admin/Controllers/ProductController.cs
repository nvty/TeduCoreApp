using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeduCoreApp.Application.Interfaces;

namespace TeduCoreApp.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        IProductService _productService;
        IProductCategoryService _producCategorytService;

        public ProductController(IProductService productService, IProductCategoryService producCategorytService)
        {
            _productService = productService;
            _producCategorytService = producCategorytService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AJAX API

            [HttpGet]
            public IActionResult GetAll()
            {
                var model = _productService.GetAll();
                return new OkObjectResult(model);
            }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var model = _producCategorytService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var model = _productService.GetAllPaging(categoryId,keyword,page,pageSize);
            return new OkObjectResult(model);
        }

        #endregion
    }
}