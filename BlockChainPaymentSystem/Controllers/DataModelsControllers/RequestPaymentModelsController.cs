using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlockChainPaymentSystem.Data;
using BlockChainPaymentSystem.Models.JsonModels;

namespace BlockChainPaymentSystem.Controllers.DataModelsController
{
    public class RequestPaymentModelsController : Controller
    {
        private readonly RequestPaymentModelContext _context;

        public RequestPaymentModelsController(RequestPaymentModelContext context)
        {
            _context = context;
        }

        // GET: RequestPaymentModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestPaymentModel.ToListAsync());
        }

        // GET: RequestPaymentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestPaymentModel = await _context.RequestPaymentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestPaymentModel == null)
            {
                return NotFound();
            }

            return View(requestPaymentModel);
        }

        // GET: RequestPaymentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestPaymentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,price_amount,price_currency,pay_amount,pay_currency,order_id,order_description,ipn_callback_url,fixed_rate,Case")] RequestPaymentModel requestPaymentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestPaymentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestPaymentModel);
        }

        // GET: RequestPaymentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestPaymentModel = await _context.RequestPaymentModel.FindAsync(id);
            if (requestPaymentModel == null)
            {
                return NotFound();
            }
            return View(requestPaymentModel);
        }

        // POST: RequestPaymentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,price_amount,price_currency,pay_amount,pay_currency,order_id,order_description,ipn_callback_url,fixed_rate,Case")] RequestPaymentModel requestPaymentModel)
        {
            if (id != requestPaymentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestPaymentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestPaymentModelExists(requestPaymentModel.Id))
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
            return View(requestPaymentModel);
        }

        // GET: RequestPaymentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestPaymentModel = await _context.RequestPaymentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestPaymentModel == null)
            {
                return NotFound();
            }

            return View(requestPaymentModel);
        }

        // POST: RequestPaymentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestPaymentModel = await _context.RequestPaymentModel.FindAsync(id);
            _context.RequestPaymentModel.Remove(requestPaymentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestPaymentModelExists(int id)
        {
            return _context.RequestPaymentModel.Any(e => e.Id == id);
        }
    }
}
