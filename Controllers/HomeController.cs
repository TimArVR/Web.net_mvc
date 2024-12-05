using WebNETFirstProj.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebNETFirstProj.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Добро пожаловать";
            //ViewBag.Categories=new List<string>();

            //Если 2 параметр НЕ СТРОКА, а первый совпадает с именем метода (action), то его можно не указывать
            return View("Index", new Person() { FirstName = "Саша", LastName = "Петров" });
        }

        //Если мы хотим возвращать наш класс в браузер, то это можно, но тогда мы лишимся функционала
        //который предоставляет IActionResult таких вещей как в методе Show - напр BadRequest NotFound и т.п.
        //Чтобы не делать обходных маневров типа эксепшенов, лучше просто обернуть в ObjectResult
        //Который уже реализует интерфейс IActionResult и позволит его вернуть.
        //public Person PersonPage() 
        //{

        //    return new Person { FirstName = "Вася", LastName = "Пупкин" };        
        //}  
        public IActionResult PersonPage()
        {

            return new ObjectResult(new Person { FirstName = "Вася", LastName = "Пупкин" });

            //И когда мы обернули наш класс в ObjectResult мы можем использовать BadRequest() NotFound()
            // и др методы которые предоставляет IActionResult
        }

        //IActionResult рекомендуется возвращать из методов
        public IActionResult Show(int id)
        {

            if (id == 10)
            {
                //Можно вернуть Content(), т.к. он реализует интерфейс IActionResult
                return Content("Show  " + id);
            }
            else if (id < 0)
            {
                //this можно опустить
                return this.BadRequest("ID отрицательный");
            }
            else
            {
                return this.NotFound();
            }
        }
        public IActionResult About()
        {
            //И поскольку наш контроллер наследуется от Controller там много интересного...
            //Например: узнать какой сейчас action
            var actionName = this.ControllerContext.ActionDescriptor.ActionName;

            //Например: узнать кто обращался к нам, каким методом в HttpContext (более короткий способ:
            // ControllerContext можно убрать this.HttpContext.Request.Method потому что у самого контроллера есть
            // редирект на HttpContext
            var example1 = this.ControllerContext.HttpContext.Request.Method;
            //какие параметры были переданы через URL
            var example2 = this.ControllerContext.HttpContext.Request.Query;
            //какие заголовки были отправлены к нам на сервер
            var example3 = this.ControllerContext.HttpContext.Request.Headers;
            return Content("Hi there");
        }

        //ПРЕДСТАВЛЕНИЯ! Чтобы вернуть представление есть метод View
        //мы можем из этого метода возвращать и ViewResult так: public ViewResult ViewMethod(){}
        //но тогда опять функцинал BadRequest() NotFound() и др из интерфейса IActionResult будет опять недоступен

        public IActionResult ViewMethod()
        {

            //Чтобы вернуть другое напр SecondView представление, мы должны его передать в качестве первого параметра
            //в метод View (если ничего не передано, то по умолчанию будет искаться представление как у метода
            //в нашем случае это ViewMеthod
            //return View("SecondView");

            //Если мы хотим параметры какие то в представлении, то даем другой параметр string "Param Value"
            //и в представлении добавляем модель string
            //return View("SecondView", "ParamValue");

            //Если 2 параметр НЕ СТРОКА, а первый совпадает с именем метода (action), то его можно не указывать
            return View("ViewMethod", new Person() { FirstName = "Вася", LastName = "Пупкин" });
        }

        public IActionResult LIST()
        {
            var people = new Person[]
            {
            new Person (){FirstName="Ваня", LastName="Иванов", Age=20 },
            new Person (){FirstName="Петя", LastName="Петров", Age=21 },
            new Person (){FirstName="Саша", LastName="Сашков", Age=22 },

            };
            return View(people);
        }
    }
}
