using csharp_sqlite_api_crud.Data;
using csharp_sqlite_api_crud.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace csharp_sqlite_api_crud.Controllers;
    
[ApiController]
[Route("api/[controller]")] 


public class CustomersController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }


    // POST: api/customers
    [HttpPost]
    public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customer);
    }


    //----- Delete Table Data -----

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return NotFound();

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }



    [HttpDelete("by-name/{Name}")]
    public async Task<IActionResult> DeleteCustomer_byName(string Name)
    {        
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == Name);
        if (customer == null) return NotFound();

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }


    
    [HttpDelete("by-id-name/{id}/{Name}")] 
    public async Task<IActionResult> DeleteCustomer_byID_Name(int id, string Name)
    {        
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == id && c.Name == Name);

        if (customer == null) return NotFound();

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }



    //----- Update Table Data -----


    // PUT: api/customers/7
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
    {        
        if (id != updatedCustomer.Id)
        {
            return BadRequest("ID mismatch");
        }
     
        _context.Entry(updatedCustomer).State = EntityState.Modified;

        try
        {         
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {            
            if (!CustomerExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent(); 
    }


    // PUT: api/customers/by-name/
    [HttpPut("by-name/{Name}")] 
    public async Task<IActionResult> UpdateCustomer_byName(string Name, Customer updatedCustomer)
    {        
        var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == Name);

        if (existingCustomer == null)
        {
            return NotFound($"Customer with name '{Name}' not found.");
        }
        
        existingCustomer.Name = updatedCustomer.Name;
        existingCustomer.City = updatedCustomer.City;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }

        return NoContent();
    }


    // PUT: api/customers/by-id-name/
    [HttpPut("by-id-name/{id}/{Name}")]
    public async Task<IActionResult> UpdateCustomer_byID_Name(int id, string Name, Customer updatedCustomer)
    {        
        var existingCustomer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == id && c.Name == Name);

        if (existingCustomer == null)
        {
            return NotFound($"No customer found with ID {id} and Name '{Name}'.");
        }

        existingCustomer.Name = updatedCustomer.Name;
        existingCustomer.City = updatedCustomer.City;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Customers.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }



    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.Id == id);
    }


}
