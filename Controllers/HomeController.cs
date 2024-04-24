using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Context;
using Project.Models.DataBase;

namespace Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Application db ;

    public HomeController(ILogger<HomeController> logger , Application _db)
    {
        _logger = logger;
        db = _db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult gotoaddstudent()
    {
        return View();
    }
    public IActionResult addstudent(Project.Models.Models.Vm_Student st)
    {
        Tbl_Student one = new Tbl_Student();
        one.Name = st.Vm_Name;
        one.Family=st.Vm_Family;
        one.Phone = st.Vm_Phone;
        one.ClassCode = st.Vm_ClassCode;
        db.tbl_student.Add(one);
        db.SaveChanges();
        return View();
    }
    public IActionResult gotoaddteacher()
    {
        return View();
    }
    public IActionResult addteacher(Project.Models.Models.Vm_Teacher Te)
    {
        Tbl_Teacher  two = new Tbl_Teacher();
        two.Name = Te.Vm_Name;
        two.Family = Te.Vm_Family;
        db.tbl_teacher.Add(two);
        db.SaveChanges();
        return View();
    }
    public IActionResult showstudent()
    {
        ViewBag.st = db.tbl_student.ToList();
        return View();
    }
    
    
    
    
}
