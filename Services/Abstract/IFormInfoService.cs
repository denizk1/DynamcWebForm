using Core.Entities.Form;
using Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IFormInfoService
    {
        BaseResponse<int> Add(FormInfo formInfo);
        BaseResponse<List<FormInfo>> GetAllFormInfo();
    }
}
