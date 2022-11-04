using frontendTR.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace frontendTR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ms_storage_location storageLocation = new ms_storage_location();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7217/api/Bpkb/GetLocation"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    storageLocation.StorageLocationList = JsonConvert.DeserializeObject<List<ms_storage_location>>(apiResponse);
                }
            }
            return View(storageLocation);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBpkbProc()
        {
            tr_bpkb bpkb = new tr_bpkb();
            bpkb.agreement_number = "";
            bpkb.bpkb_no = HttpContext.Request.Form["bpkb_no"];
            bpkb.branch_id = HttpContext.Request.Form["branch_id"];
            bpkb.bpkb_date = HttpContext.Request.Form["bpkb_date"];
            bpkb.bpkb_date_in = HttpContext.Request.Form["bpkb_date_in"];
            bpkb.faktur_no = HttpContext.Request.Form["faktur_no"];
            bpkb.faktur_date = HttpContext.Request.Form["faktur_date"];
            bpkb.location_id = HttpContext.Request.Form["location_id"];
            bpkb.police_no = HttpContext.Request.Form["police_no"];

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bpkb), Encoding.UTF8, "application/json");
                Console.WriteLine(JsonConvert.SerializeObject(bpkb));

                using (var response = await httpClient.PostAsync("https://localhost:7217/api/Bpkb/AddBpkb", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("result : " + apiResponse);
                    if (apiResponse == "Success")
                    {
                        TempData["msgResult"] = "Notiflix.Report.Success('Success', 'Tambah Data Berhasil', 'Okey', function () {window.location.replace('" + Url.Action("Index", "Home") + "');});";
                    }
                    else
                    {
                        TempData["msgResult"] = "Notiflix.Report.Error('Success', 'Tambah Data Gagal', 'Okey', function () {window.location.replace('" + Url.Action("AddEmployee", "Home") + "');});";
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}