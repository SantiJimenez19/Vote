﻿

namespace Vote.Web.Controllers
{
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Vote.Web.Data;
    using Vote.Web.Data.Entities;
    using Models;
    using System.IO;
    using System;

    public class CandidatesController : Controller
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IUserHelper userHelper;

        public CandidatesController(ICandidateRepository candidateRepository , IUserHelper userHelper)
        {

            this.candidateRepository = candidateRepository;
            this.userHelper = userHelper;
        }

        // GET: Candidates
        public IActionResult Index()
        {
            return View(this.candidateRepository.GetAll());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate= await this.candidateRepository.GetByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidateViewModel view) 
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), 
                           "wwwroot\\images\\Candidates", 
                            view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Candidates/{view.ImageFile.FileName}";
                }

                var candidate = this.ToCandidate(view, path);

                // TODO: Pending to change to: this.User.Identity.Name
                candidate.User = await this.userHelper.GetUserByEmailAsync("santisuarez1100@gmail.com");
                await this.candidateRepository.CreateAsync(candidate);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Candidate ToCandidate(CandidateViewModel view, string path)
        {
            return new Candidate
            {
                Id = view.Id,
                ImageUrl = path,
                Name = view.Name,
                Proposal = view.Proposal,
                Votes = view.Votes,
                User = view.User
            };
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await this.candidateRepository.GetByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Pending to change to: this.User.Identity.Name
                   candidate.User = await this.userHelper.GetUserByEmailAsync("santisuarez1100@gmail.com");
                    await this.candidateRepository.UpdateAsync(candidate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.candidateRepository.ExistAsync(candidate.Id))
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

            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await this.candidateRepository.GetByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await this.candidateRepository.GetByIdAsync(id);
            await this.candidateRepository.DeleteAsync(candidate);
            return RedirectToAction(nameof(Index));
        }
    }

}