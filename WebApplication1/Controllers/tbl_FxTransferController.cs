using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tbl_FxTransferController : Controller
    {
        private ExchangeDBEntities db = new ExchangeDBEntities();

        // GET: tbl_FxTransfer
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_FxTransfer.ToListAsync());
        }

        // GET: tbl_FxTransfer/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FxTransfer tbl_FxTransfer = await db.tbl_FxTransfer.FindAsync(id);
            if (tbl_FxTransfer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FxTransfer);
        }

        // GET: tbl_FxTransfer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_FxTransfer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FxTransferId,FxTVoucherNo,FxTInvoiceNo,FxTVoucherTypeId,depositReceipt,PartnerLedgerId,CurrencyId,amount,transactionDate,Narration,BankLedgerId,version,paymentMode,chequeNo,chequeDate,chequeComment,createdDate,createdBy,lastUpdate,lastUpdateBy")] tbl_FxTransfer tbl_FxTransfer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_FxTransfer.Add(tbl_FxTransfer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_FxTransfer);
        }

        // GET: tbl_FxTransfer/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FxTransfer tbl_FxTransfer = await db.tbl_FxTransfer.FindAsync(id);
            if (tbl_FxTransfer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FxTransfer);
        }

        // POST: tbl_FxTransfer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FxTransferId,FxTVoucherNo,FxTInvoiceNo,FxTVoucherTypeId,depositReceipt,PartnerLedgerId,CurrencyId,amount,transactionDate,Narration,BankLedgerId,version,paymentMode,chequeNo,chequeDate,chequeComment,createdDate,createdBy,lastUpdate,lastUpdateBy")] tbl_FxTransfer tbl_FxTransfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_FxTransfer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_FxTransfer);
        }

        // GET: tbl_FxTransfer/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FxTransfer tbl_FxTransfer = await db.tbl_FxTransfer.FindAsync(id);
            if (tbl_FxTransfer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FxTransfer);
        }

        // POST: tbl_FxTransfer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            tbl_FxTransfer tbl_FxTransfer = await db.tbl_FxTransfer.FindAsync(id);
            db.tbl_FxTransfer.Remove(tbl_FxTransfer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
