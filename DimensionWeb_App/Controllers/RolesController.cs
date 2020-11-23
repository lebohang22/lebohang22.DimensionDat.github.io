using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DimensionWeb_App.Data;
using DimensionWeb_App.Models;
using Microsoft.AspNetCore.Identity;

namespace DimensionWeb_App.Controllers
{
    public class RolesController : Controller
    {

        //private readonly DimensionDataContext _context;//
        RoleManager<IdentityRole> roleManager;

        /*public RolesController(DimensionDataContext context)
        {
            _context = context;
        }
        */

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

       
        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AspNetRoles role)
        {
            var roleExist = await roleManager.RoleExistsAsync(role.Name);
            if (!roleExist)
            {
                
                var result = await roleManager.CreateAsync(new IdentityRole(role.Name));
            }
            return View(new AspNetRoles());
        }

        // GET: Roles/Edit/5
        /*public async Task<IActionResult> Edit(string id)
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

        // POST: Roles/Edit/5
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

        // GET: Roles/Delete/5
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

        // POST: Roles/Delete/5
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
        */
    }
}
