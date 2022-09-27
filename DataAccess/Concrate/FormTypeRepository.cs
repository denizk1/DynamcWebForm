using Core.DataAccess.EF;
using Core.Entities.Form;
using DataAccess.Abstract;
using DataAccess.Concrate.Ef.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate
{
    public class FormTypeRepository : EfRepository<FormType, FormContext>, IFormTypeRepository
    {
    }
}
