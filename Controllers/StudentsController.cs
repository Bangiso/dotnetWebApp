using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetWebApp.Models;
using dotnetWebApp.Services;
using dotnetWebApp.Daos;

namespace dotnetWebApp.Controllers;

public class StudentsController : Controller
{
    private readonly ILogger<StudentsController> _logger;

    public StudentsController(ILogger<StudentsController> logger)
    {
        _logger = logger;
    }

   public IActionResult Index()
    {
        StudentService _studanetDao = new StudentDao();
        return View( _studanetDao.getStudents());
    }

    public IActionResult GetAll()
    {
        StudentService _studanetDao = new StudentDao();
        return View( _studanetDao.getStudents());
    }

    public IActionResult Details(int id)
    {
        StudentService _studanetDao = new StudentDao();
        return View(_studanetDao.getStudentById(id));
    }

    public IActionResult Create(int id, string name, double gpa)
    {

        StudentService _studanetDao = new StudentDao();
        ViewBag.results = null;
        if(id!=0 && name!=null && gpa!=0){
           ViewBag.results = _studanetDao.addStudent(new StudentViewModel(id, name, gpa));
          }
        return View();
    }

    public IActionResult Update(int id, string name, double gpa)
    {
        StudentService _studanetDao = new StudentDao();
        ViewBag.results = null;
        if(id!=0 && name!=null & gpa!=0){
           ViewBag.results = _studanetDao.updateStudent(new StudentViewModel(id, name, gpa));
          }
        return View();
    }

    public RedirectToActionResult Delete(int id)
    {

        StudentService _studanetDao = new StudentDao();
        ViewBag.results = _studanetDao.removeStudent(id);
        return RedirectToAction(actionName: "Index", controllerName: "Students");
    }

   public IActionResult Search(string keyword)
    {
        StudentService _studanetDao = new StudentDao();
        if(keyword==null){
            return RedirectToAction(actionName: "GetAll", controllerName: "Students");
        }
        return View( "GetAll", _studanetDao.getStudents().Where(st => st.Name.Contains(keyword)).ToList() );
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
}