using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SeyfolioWeb.Areas.Writer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SeyfolioWeb.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class DashboardWriterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        CityManager _cityManager = new CityManager(new EfCityDal());

        public DashboardWriterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.isActive = "/Writer/DashboardWriter/Index";

            var user  = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = user.UserName;
            Context context = new Context();
            ViewBag.gelenMesajSayisi = context.WriterMessages.Where(x => x.Receiver == user.Email).Count();
            ViewBag.duyusuSayisi = context.Announcements.Count();
            ViewBag.kullaniciSayisi = _userManager.Users.Count();
            ViewBag.yetenekSayisi = context.Skills.Count();

        //TODO: Api kullanım sayısı bitmemesi için comment e alındı
            string apiKey = "600daf6984e3483189a144509242404";
            string city = _cityManager.GetList().Where(x=>x.isSelected==true).FirstOrDefault().CityName;
            string apiConnection = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";


            WeatherData weatherData = await GetWeatherDataAsync(apiConnection);
            string cityName = weatherData.location.name;
            string countryName = weatherData.location.country;
            double temperatureInCelsius = weatherData.current.temp_c;
            string icon = weatherData.current.condition.icon;
            string conditionText = weatherData.current.condition.text;
            double humidity = weatherData.current.humidity;
            double windSpeed = weatherData.current.wind_kph;
            double windDegree = weatherData.current.wind_degree;

            ViewBag.cityName = cityName;
            ViewBag.countryName = countryName;
            ViewBag.temperatureInCelsius = temperatureInCelsius;
            ViewBag.icon = icon;
            ViewBag.conditionText = conditionText;
            ViewBag.humidity = humidity;
            ViewBag.windSpeed = windSpeed;
            ViewBag.windDegree = windDegree;

            var cities = _cityManager.GetList();

            SelectList citySelectList = new SelectList(cities,"CityId","CityName");

            ViewBag.citySelectList = citySelectList;


            return View();
        }



        public async Task<IActionResult> CityChangeAsync(int selectedCity)
        {
           List<Cities> cities = _cityManager.GetList().Where(x=>x.isSelected == true).ToList();
            foreach (var item in cities)
            {
                item.isSelected = false;
            }

            _cityManager.GetById(selectedCity).isSelected=true;
            //using Context context = new Context();
            //await context.SaveChangesAsync();
            _cityManager.TSave();



            return RedirectToAction("Index");
        }

        public async Task<WeatherData> GetWeatherDataAsync(string apiConnection)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiConnection);



                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    WeatherData _weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                    return _weatherData;
                }
                else
                {
                    // Handle error
                    return null;
                }
            }



            
        }





    }
}
