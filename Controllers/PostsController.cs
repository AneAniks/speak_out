using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpeakOut.Data;
using SpeakOut.Models;

namespace SpeakOut.Controllers
{
    public class PostsController : Controller
    {
        private readonly SpeakOutContext _context;

        public PostsController(SpeakOutContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var speakOutContext = _context.Posts.Include(p => p.CategoryNavigation).Include(p => p.User);
            return View(await speakOutContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .Include(p => p.CategoryNavigation)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Post,UserId,CategoryId")] Posts posts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", posts.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", posts.UserId);
            return View(posts);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", posts.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", posts.UserId);
            return View(posts);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Post,UserId,CategoryId")] Posts posts)
        {
            if (id != posts.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostsExists(posts.PostId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", posts.CategoryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", posts.UserId);
            return View(posts);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.Posts
                .Include(p => p.CategoryNavigation)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
