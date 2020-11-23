using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimensionWeb_App.Data;
using DimensionWeb_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DimensionWeb_App.Controllers
{
    public class DimensionDatasController : Controller
    {
        private readonly DimensionDataContext _context;
       

        public DimensionDatasController(DimensionDataContext context)
        {
            _context = context;
        }

       
        // GET: DimensionDatas

        public async Task<IActionResult> Index()
        {
            return View(await _context.DimensionData.ToListAsync());
        }

        // GET: DimensionDatas/Details/5
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionData = await _context.DimensionData
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (dimensionData == null)
            {
                return NotFound();
            }

            return View(dimensionData);
        }

        // GET: DimensionDatas/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: DimensionDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] DimensionData dimensionData)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(dimensionData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(dimensionData);
        }

        // GET: DimensionDatas/Edit/5
        
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionData = await _context.DimensionData.FindAsync(id);
            if (dimensionData == null)
            {
                return NotFound();
            }
            return View(dimensionData);
        }

        // POST: DimensionDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(string id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] DimensionData dimensionData)
        {
            if (id != dimensionData.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dimensionData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DimensionDataExists(dimensionData.EmployeeNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dimensionData);
        }

        // GET: DimensionDatas/Delete/5
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dimensionData = await _context.DimensionData
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (dimensionData == null)
            {
                return NotFound();
            }

            return View(dimensionData);
        }

        // POST: DimensionDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dimensionData = await _context.DimensionData.FindAsync(id);
            _context.DimensionData.Remove(dimensionData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DimensionDataExists(string id)
        {
            return _context.DimensionData.Any(e => e.EmployeeNumber == id);
        }
    }
}
