﻿using EF_Practise.DTOs.Brand;
using EF_Practise.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practise.Services.Interfaces
{
    public interface IBrandService
    {
        void Create(BrandCreateDto brand);
        void Update(int id,Brand brand);
        void Delete(int? id);
        Brand GetById(int id);
        List<BrandGetDto> GetAll();

    }
}
