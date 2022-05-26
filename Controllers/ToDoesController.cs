using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KanbanProject.Models;

namespace KanbanProject.Controllers
{
    public class ToDoesController : Controller
    {
        private readonly ToDoContexto _context;

        public ToDoesController(ToDoContexto context)
        {
            _context = context;
        }

        // GET: ToDoes
        public async Task<IActionResult> Index(int? id, string Fazendo, string Pedro)
        {
            var produto = await _context.ToDos.FindAsync(id);
            if (produto != null)
            {
                switch (Fazendo)
                {
                    case "1":
                        _context.Add(new ToDo { Inprogress = produto.Resquested });
                        await _context.SaveChangesAsync();
                        _context.ToDos.Remove(produto);
                        await _context.SaveChangesAsync();
                        break;
                    case "2":
                        _context.Add(new ToDo { Done = produto.Inprogress });
                        await _context.SaveChangesAsync();
                        _context.ToDos.Remove(produto);
                        await _context.SaveChangesAsync();
                        break;
                    case "3":
                        _context.Add(new ToDo { Resquested = produto.Inprogress });
                        await _context.SaveChangesAsync();
                        _context.ToDos.Remove(produto);
                        await _context.SaveChangesAsync();
                        break;
                    case "4":
                        _context.Add(new ToDo { Inprogress = produto.Done });
                        await _context.SaveChangesAsync();
                        _context.ToDos.Remove(produto);
                        await _context.SaveChangesAsync();
                        break;
                    case "5":

                        _context.ToDos.Remove(produto);
                        await _context.SaveChangesAsync();
                        break;
                }
            }
            if (Pedro != null)
            {
                _context.Add(new ToDo { Resquested = Pedro });
                await _context.SaveChangesAsync();
            }
            return _context.ToDos != null ?
                          View(await _context.ToDos.ToListAsync()) :
                          Problem("Entity set 'ToDoContexto.ToDos'  is null.");
        }

        // GET: ToDoes/Details/5

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Resquested,Inprogress,Done")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
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
            return View(toDo);
        }

        // GET: ToDoes/Delete/5

        // POST: ToDoes/Delete/5



        private bool ToDoExists(int id)
        {
            return (_context.ToDos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
