using Microsoft.AspNetCore.Mvc;

public class CustomerController : Controller
{
  // this controller depends on the NorthwindRepository
  private DataContext _dataContext;
  public CustomerController(DataContext db) => _dataContext = db;
  public IActionResult Register() => View();

  [HttpPost]
  public IActionResult Registered(Customer newCustomer) {
    if (!_dataContext.Customers.Any(c => c.CompanyName == newCustomer.CompanyName)){
      _dataContext.Add( new Customer() {
        CompanyName = newCustomer.CompanyName,
        Address = newCustomer.Address,
        City = newCustomer.City,
        Region = newCustomer.Region,
        PostalCode = newCustomer.PostalCode,
        Country = newCustomer.Country,
        Phone = newCustomer.Phone,
        Fax = newCustomer.Fax
      });

      _dataContext.SaveChanges();
    }

    return View(_dataContext.Customers.OrderBy(c => c.CompanyName));
  }
}