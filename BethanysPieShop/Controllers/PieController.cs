﻿using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using BethanysPieShop.ViewModels;


namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
       private readonly IPieRepository _pieRepository;
       private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List() 
        {
            PieListViewModel pieListViewModel = new PieListViewModel
                (_pieRepository.AllPies, "All Pies");
            return View(pieListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null) 
                return NotFound();
            return View(pie);
        }
    }
}
