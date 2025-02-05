﻿using PokemonGame.Architecture.Services;
using PokemonGame.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace PokemonGame.Main.Controllers
{
    public class TrainerController : Controller
    {
        private readonly PokemonBDEntities _db;
        private readonly TeamService _teamService;
        private readonly MessageService _messageService;
        private readonly UserService _userService;

        public TrainerController()
        {
            _teamService = new TeamService();
            _db = new PokemonBDEntities();
            _messageService = new MessageService();
            _userService = new UserService();
        }

        public ActionResult Index()
        {
            var sessionId = Request.Cookies["session_id"]?.Value;
            int id = Int32.Parse(sessionId);

            if (string.IsNullOrEmpty(sessionId))
            {
                return RedirectToAction("Index", "Home");
            }

            IEnumerable<User> users = _userService.GetUsersDB(id);
            ViewBag.User = users;

            Team team = _db.Teams.SingleOrDefault(t => t.User.UserId == id);

            if (team == null)
            {
                ModelState.AddModelError("", "You don't have a team");
            }

            IEnumerable<Message> messages = _messageService.GetMesagesDB(id);
            ViewBag.Mesages = messages;

            return View(team);
        }

        //Teams
        public ActionResult CreateTeam()
        {
            var pokemonList = _db.Pokemons
            .Select(p => new SelectListItem
            {
                Value = p.PokemonId.ToString(),
                Text = p.Name
            }) .ToList();

            ViewBag.PokemonList = pokemonList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateTrainerTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                var sessionId = Request.Cookies["session_id"]?.Value;
                int id = Int32.Parse(sessionId);

                team.UserId = id;

                _db.Teams.Add(team);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.PokemonList = _db.Pokemons
                .Select(p => new SelectListItem
                {
                    Value = p.PokemonId.ToString(),
                    Text = p.Name
                })
                .ToList();

            return View(team);
        }

        public ActionResult DeleteTeam(int id)
        {
            bool isSuccess = _teamService.DeleteTeamDB(id);

            if (isSuccess)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        //Messages

        public ActionResult CreateMessage(int receiverId)
        {
            var sessionId = Request.Cookies["session_id"]?.Value;
            int id = Int32.Parse(sessionId);
            var senderId = id;

            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId
            };

            return View(message);
        }


        [HttpPost]
        public ActionResult CreateMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                var sessionId = Request.Cookies["session_id"]?.Value;
                int id = Int32.Parse(sessionId);

                var success = _messageService.CreateMessageDB(id, message.ReceiverId, message.Content);
                if (success)
                {
                    return RedirectToAction("Index", "Trainer"); 
                }
            }

            return View(message);
        }

        public ActionResult DeleteMessage(int id)
        {
            bool isSuccess = _messageService.DeleteMessageDB(id);

            if (isSuccess)
            {
                return View("Index");
            }

            return View("Index");
        }
    }
}