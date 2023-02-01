using Microsoft.AspNetCore.Mvc;

using MyTourManagementMVC.Helper;
using MyTourManagementMVC.Models;
using Newtonsoft.Json;

namespace MyTourManagementMVC.Controllers
{
    public class UserController : Controller
    {
        MyTourAPI aPI = new MyTourAPI();
        public async Task<IActionResult> Index()
        {
            List<UserRegisterDetails> users = new List<UserRegisterDetails>();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Registration/GetAllUsers");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UserRegisterDetails>>(results);

            }
            return View(users);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var user = new UserRegisterDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Registration/GetUser/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserRegisterDetails>(results);
            }
            return View(user);
        }
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult create(UserRegisterDetails user)
        {
            HttpClient client = aPI.Initial();
            var addUser = client.PostAsJsonAsync<UserRegisterDetails>("api/Registration/AddUser", user);
            addUser.Wait();
            var result = addUser.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("RegisterSuccess", "User");
            }
            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var user = new UserRegisterDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Registration/DeleteUser/{Id}");
            return RedirectToAction("Index");
        }
        public IActionResult RegisterSuccess()
        {
            return View();
        }

       public IActionResult UserLogin()
        {
            return View();
        }
      /*  public async Task<IActionResult> UserLogin(string useremail,string password)
        {
            /*var result=new UserRegisterDetails();
            HttpClient client=aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Registration/LoginUser/{useremail}/{password}");
            if (res.IsSuccessStatusCode)
            {
                 result = res.Content.ReadAsStringAsync().Result;
               
            }
           
            
            return View(results);
            var user = new UserRegisterDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Registration/UserLogin/{useremail}/{password}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserRegisterDetails>(results);
            }
            return View(user);

        }*/

        /*public async Task<IActionResult> DetailsByPhoneNumber(string phno)
        {
            phno = Request.Form["txtphno"];
            var user = new UserRegisterDetails();
            HttpClient client = aPI.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Registration/GetUserByPhoneNumber/{phno}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserRegisterDetails>(results);
            }
            return View(user);
        }
        */

        /*public async Task<IActionResult> Edit(UserRegisterDetails user)
        {
            
            HttpClient client = aPI.Initial();
            HttpResponseMessage res=  await client.PutAsync<UserRegisterDetails>("api/User",user);
            updateUser.Wait();

            return RedirectToAction("Index");
        }*/


    }
}
