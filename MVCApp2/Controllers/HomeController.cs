using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp2.Models;


namespace MVCApp2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(int num,int guess)
        {
            string highOrLow;
            bool winner = false;

            //If this is the users first guess, I get a random seed to use for the random number genorator
            //I'm passing the seed back and forth between calls as a unique ID to this game session
            if (num == 0)
            {
                int randomSeed = new Random().Next();
                int randomNum = new Random(randomSeed).Next(1, 100);
                highOrLow = CheckGuess(guess, randomNum);

                if(highOrLow == "You Win!")
                {
                    winner = true;
                }

                GameModel game = new GameModel
                {
                    Seed = randomSeed,

                    Guess = guess,

                    HighOrLow = highOrLow,

                    Winner = winner
                };
                return Json(game);

            }
            else
            {
             // If the user already has a seed that they pass I find the number they are going for and check if their guess is Lower, Higher, or Right
             
                int randomNum = new Random(num).Next(1, 100);

                highOrLow = CheckGuess(guess, randomNum);

                if (highOrLow == "You Win!")
                {
                    winner = true;
                }


                GameModel game = new GameModel
                {
                    Seed = num,

                    Guess = guess,

                    HighOrLow = highOrLow,

                    Winner = winner
                };
                return Json(game);

                

            }

            
            
            
        }

        //extracted this method to clean up the ajaxMethod
        private static string CheckGuess(int guess, int randomNum)
        {
            string highOrLow;
            if (randomNum == guess)
            {
                
                highOrLow = "You Win!";
            }
            else if (randomNum > guess)
            {
                highOrLow = "You are to low!";
            }
            else
            {
                highOrLow = "You are to High!";
            }

            return highOrLow;
        }
    }
}