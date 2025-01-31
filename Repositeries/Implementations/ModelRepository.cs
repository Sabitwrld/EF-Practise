using EF_Practise.Data;
using EF_Practise.Entities;
using EF_Practise.Repositeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practise.Repositeries.Implementations
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
