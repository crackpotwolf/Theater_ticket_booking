﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Theater_ticket_booking.ModelsView.UserModels;
using Theater_ticket_booking.Repositories;

namespace Theater_ticket_booking.Controllers
{
    [Authorize]
    [Route("/Account")]
    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger, UsersRepository userRepository) : base(userRepository)
        {
            _logger = logger;
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login() => View();


        [HttpGet("Registration")]
        [AllowAnonymous]
        public IActionResult Registration() => View();

        /// <summary>
        /// Настройки аккаунта пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> Account()
        {
            var user = _userRepository
                .GetList()
                .FirstOrDefault(p => p.Id == CurrentUserId());

            return View(new UserView(user));
        }
    }
}
