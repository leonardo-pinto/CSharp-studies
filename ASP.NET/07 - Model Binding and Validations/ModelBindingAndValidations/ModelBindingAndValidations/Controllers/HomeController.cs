﻿using Microsoft.AspNetCore.Mvc;
using ModelBindingAndValidations.Models;


namespace ModelBindingAndValidations.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isLoggedIn?}")]
        // Example Model Binding
        // Priority
        //
        //
        // Route Data
        // Query String
        // method parameter is a shortcut
        // to Request.Query

        // [FromRoute] int? bookid to use route
        // [FromQuery] int? bookid to use query instead of route
        public IActionResult Index(int? bookid, bool? isLoggedIn, Book book)
        {
            // book is assigned through route data !!!
            // it is NOT case sensitive

            // must add [FromQuery] from Model Class !
            if (bookid.HasValue == false)
            {
                return BadRequest("Book is was not supplied");
            }
            if (bookid <= 0)
            {
                return BadRequest("Book id can not be less than or equal to zero");
            }
            if (isLoggedIn.HasValue == false || isLoggedIn == false)
            {
                return StatusCode(401);
            }

            return Content($"<h1>{book?.ToString()}</h1>", "text/html");
        }
    }
}