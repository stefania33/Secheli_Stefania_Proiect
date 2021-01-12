using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreModel.Data;
using StoreModel.Models;
using Secheli_Stefania_Proiect.Models.StoreViewModels;

namespace Secheli_Stefania_Proiect.Controllers
{
    public class RecordersController : Controller

    {
        private readonly StoreContext _context;

        public RecordersController(StoreContext context)
        {
            _context = context;
        }

        // GET: Recorders
        public async Task<IActionResult> Index(int? id, int? albumID)
        {
            var viewModel = new RecorderIndexData
            {
                Recorders = await _context.Recorders
            .Include(i => i.RecordedAlbums)
            .ThenInclude(i => i.Album)
            .ThenInclude(i => i.Orders)
            .ThenInclude(i => i.Customer)
            .AsNoTracking()
            .OrderBy(i => i.RecorderName)
            .ToListAsync()
            };

            if (id != null)
            {
                ViewData["RecorderID"] = id.Value;
                Recorder recorder = viewModel.Recorders.Where(
                i => i.ID == id.Value).Single();
                viewModel.Albums = recorder.RecordedAlbums.Select(s => s.Album);
            }
            if (albumID != null)
            {
                ViewData["AlbumID"] = albumID.Value;
                viewModel.Orders = viewModel.Albums.Where(
                x => x.ID == albumID).Single().Orders;
            }
            return View(viewModel);
        }

        // GET: Recorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recorder = await _context.Recorders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recorder == null)
            {
                return NotFound();
            }

            return View(recorder);
        }

        // GET: Recorders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RecorderName,Adress")] Recorder recorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recorder);
        }

        // GET: Recorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recorder = await _context.Recorders
            .Include(i => i.RecordedAlbums).ThenInclude(i => i.Album)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);
            if (recorder == null)
            {
                return NotFound();
            }
            PopulateRecordedAlbumData(recorder);
            return View(recorder);
        }
        private void PopulateRecordedAlbumData(Recorder recorder)
        {
            var allAlbums = _context.Albums;
            var recorderAlbums = new HashSet<int>(recorder.RecordedAlbums.Select(c => c.AlbumID));
            var viewModel = new List<RecordedAlbumData>();
            foreach (var album in allAlbums)
            {
                viewModel.Add(new RecordedAlbumData
                {
                    AlbumID = album.ID,
                    Name = album.Name,
                    IsRecorded = recorderAlbums.Contains(album.ID)
                });
            }
            ViewData["Albums"] = viewModel;
        }

        // POST: Recorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedAlbums)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recorderToUpdate = await _context.Recorders
            .Include(i => i.RecordedAlbums)
            .ThenInclude(i => i.Album)
            .FirstOrDefaultAsync(m => m.ID == id);
            if (await TryUpdateModelAsync<Recorder>(
            recorderToUpdate,
            "",
            i => i.RecorderName, i => i.Adress))
            {
                UpdateRecordedAlbums(selectedAlbums, recorderToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, ");
                }
                return RedirectToAction(nameof(Index));
            }
            UpdateRecordedAlbums(selectedAlbums, recorderToUpdate);
            PopulateRecordedAlbumData(recorderToUpdate);
            return View(recorderToUpdate);
        }

        private void UpdateRecordedAlbums(string[] selectedAlbums, Recorder recorderToUpdate)
        {
            if (selectedAlbums == null)
            {
                recorderToUpdate.RecordedAlbums = new List<RecordedAlbum>();
                return;
            }
            var selectedAlbumsHS = new HashSet<string>(selectedAlbums);
            var recordedAlbums = new HashSet<int>
            (recorderToUpdate.RecordedAlbums.Select(c => c.Album.ID));
            foreach (var album in _context.Albums)
            {
                if (selectedAlbumsHS.Contains(album.ID.ToString()))
                {
                    if (!recordedAlbums.Contains(album.ID))
                    {
                        recorderToUpdate.RecordedAlbums.Add(new RecordedAlbum { RecorderID = recorderToUpdate.ID, AlbumID = album.ID });
                    }
                }
                else
                {
                    if (recordedAlbums.Contains(album.ID))
                    {
                        RecordedAlbum albumToRemove = recorderToUpdate.RecordedAlbums.FirstOrDefault(i => i.AlbumID == album.ID);
                        _context.Remove(albumToRemove);
                    }
                }
            }
        }
       

        // POST: Recorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recorder = await _context.Recorders.FindAsync(id);
            _context.Recorders.Remove(recorder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecorderExists(int id)
        {
            return _context.Recorders.Any(e=> e.ID == id);
        }
    }
}
