using Labb4_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_MVC.Controllers
{
    public class LoanController : Controller
    {
        
        private readonly AppDBContext context;

        public LoanController(AppDBContext context)
        {
            this.context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = context.Loans.Include(b => b.Books).Include(b => b.Customers);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Loan = await context.Loans
                .Include(b => b.Books)
                .Include(b => b.Customers)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (Loan == null)
            {
                return NotFound();
            }

            return View(Loan);
        }

        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["FkBookId"] = new SelectList(context.Books, "BookId", "Description");
            ViewData["FkCustomerId"] = new SelectList(context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanId,FkCustomerId,FkBookId,LoanDate,ReturnDate")] Loan Loan)
        {
            if (ModelState.IsValid)
            {
                context.Add(Loan);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBookId"] = new SelectList(context.Books, "BookId", "Description", Loan.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(context.Customers, "CustomerId", "CustomerName", Loan.FkCustomerId);
            return View(Loan);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Loan = await context.Loans.FindAsync(id);
            if (Loan == null)
            {
                return NotFound();
            }
            ViewData["FkBookId"] = new SelectList(context.Books, "BookId", "Description", Loan.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(context.Customers, "CustomerId", "CustomerName", Loan.FkCustomerId);
            return View(Loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanId,FkCustomerId,FkBookId,LoanDate,ReturnDate")] Loan Loan)
        {
            if (id != Loan.LoanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(Loan);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookLoanExists(Loan.LoanId))
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
            ViewData["FkBookId"] = new SelectList(context.Books, "BookId", "Description", Loan.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(context.Customers, "CustomerId", "CustomerName", Loan.FkCustomerId);
            return View(Loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Loan = await context.Loans
                .Include(b => b.Books)
                .Include(b => b.Customers)
                .FirstOrDefaultAsync(m => m.LoanId == id);
            if (Loan == null)
            {
                return NotFound();
            }

            return View(Loan);
        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Loan = await context.Loans.FindAsync(id);
            context.Loans.Remove(Loan);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookLoanExists(int id)
        {
            return context.Loans.Any(e => e.LoanId == id);
        }
    }
    
}
