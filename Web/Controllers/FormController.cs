using Core.Entities.Form;
using Core.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormTypeService _formTypeService;
        private readonly IFormInfoService _formInfoService;
        public FormController(IFormTypeService formTypeService,
            IFormInfoService formInfoService
            )
        {
            _formTypeService = formTypeService;
            _formInfoService = formInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FormList()
        {
            List<FormInfo> result = _formInfoService.GetAllFormInfo().Data;
            return View(result);
        }
        public IActionResult FormDetail()
        {
            return View();
        }
        public IActionResult CreateForm(int Id)
        {
            return View();
        }
        public JsonResult AddForm(int Id)
        {
            var result = _formTypeService.GetById(Id).Data;
            return Json(new BaseResponse<FormType>(true, result, "İşlem Başarılı."));
        }
        [HttpPost]
        public JsonResult AddDynamicForm(List<FormData> formdatas,string formName="Yeni")
        {
            string json = JsonConvert.SerializeObject(formdatas, Formatting.Indented);
            FormInfo formInfo = new FormInfo();
            formInfo.jsonformat = json;
            formInfo.FormName = formName;

            var result = _formInfoService.Add(formInfo);

            

            return Json(new BaseResponse<int>(true, 1, "İşlem Başarılı."));
        }

    }
}
