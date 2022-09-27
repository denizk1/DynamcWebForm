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
    public class FormInfoService:IFormInfoService
    {
        private readonly IFormInfoRepository _formInfoRepository;
        public FormInfoService(IFormInfoRepository formInfoRepository)
        {
            _formInfoRepository = formInfoRepository;
        }

        public BaseResponse<int> Add(FormInfo formInfo )
        {
            var result = _formInfoRepository.Add(formInfo);

            return new BaseResponse<int>(true, 1, "");
        }
        public BaseResponse<List<FormInfo>> GetAllFormInfo()
        {
            List<FormInfo> formInfos = new List<FormInfo>();
            formInfos = _formInfoRepository.GetAll().Data;

            return new BaseResponse<List<FormInfo>>(true, formInfos, "");
        }
    }
}
