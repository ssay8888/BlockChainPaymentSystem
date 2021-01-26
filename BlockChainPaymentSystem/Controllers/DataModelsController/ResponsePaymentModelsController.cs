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
    public class ResponsePaymentModelsController : Controller
    {
        private readonly ResponsePaymentModelContext _context;

        public ResponsePaymentModelsController(ResponsePaymentModelContext context)
        {
            _context = context;
        }

        // GET: ResponsePaymentModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResponsePaymentModel.ToListAsync());
        }

        // GET: ResponsePaymentModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsePaymentModel = await _context.ResponsePaymentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsePaymentModel == null)
            {
                return NotFound();
            }

            return View(responsePaymentModel);
        }

        // GET: ResponsePaymentModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsePaymentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,payment_id,payment_status,pay_address,price_amount,price_currency,pay_amount,pay_currency,actually_paid,order_id,order_description,payin_extra_id,ipn_callback_url,created_at,updated_at,purchase_id,outcome_amount,outcome_currency")] ResponsePaymentModel responsePaymentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsePaymentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsePaymentModel);
        }

        // GET: ResponsePaymentModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsePaymentModel = await _context.ResponsePaymentModel.FindAsync(id);
            if (responsePaymentModel == null)
            {
                return NotFound();
            }
            return View(responsePaymentModel);
        }

        // POST: ResponsePaymentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,payment_id,payment_status,pay_address,price_amount,price_currency,pay_amount,pay_currency,actually_paid,order_id,order_description,payin_extra_id,ipn_callback_url,created_at,updated_at,purchase_id,outcome_amount,outcome_currency")] ResponsePaymentModel responsePaymentModel)
        {
            if (id != responsePaymentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsePaymentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsePaymentModelExists(responsePaymentModel.Id))
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
            return View(responsePaymentModel);
        }

        // GET: ResponsePaymentModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsePaymentModel = await _context.ResponsePaymentModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsePaymentModel == null)
            {
                return NotFound();
            }

            return View(responsePaymentModel);
        }

        // POST: ResponsePaymentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsePaymentModel = await _context.ResponsePaymentModel.FindAsync(id);
            _context.ResponsePaymentModel.Remove(responsePaymentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsePaymentModelExists(int id)
        {
            return _context.ResponsePaymentModel.Any(e => e.Id == id);
        }
    }
}
