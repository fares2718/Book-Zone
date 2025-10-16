﻿using BookZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookZone.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ApplicationDbContext _context;

        public CategoriesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _context.Categories
                        .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                        .OrderBy(c => c.Text)
                        .AsNoTracking()
                        .ToList();
        }
    }
}
