using Core.Entities.Form;
using Core.Models.Response;
using DataAccess.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrate
{
    public class FormTypeService:IFormTypeService
    {
        private readonly IFormTypeRepository _formTypeRepository;
        public FormTypeService(IFormTypeRepository formTypeRepository)
        {
            _formTypeRepository = formTypeRepository;
        }
        public BaseResponse<FormType> GetById(int Id)
        {
            var result = _formTypeRepository.Get(s => s.Id == Id);

            return new BaseResponse<FormType>(true, result.Data, "");
        }

    }
}
