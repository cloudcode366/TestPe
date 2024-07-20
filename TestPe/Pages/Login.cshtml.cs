using DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Repository;
using System.ComponentModel.DataAnnotations;

namespace TestPe.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountRepo _accountRepo;
        public LoginModel(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }
        [EmailAddress]
        [Required]
        [Display(Name = "Account Email")]
        [BindProperty]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }
        //--------------------

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            var tmp = (await _accountRepo.GetAllAsync()).FirstOrDefault(p=>p.AccountEmail.Equals(Email)&&p.AccountPassword.Equals(Password));
            var role = tmp.Role;
            if (!(role == (int)RoleEnum.Staff || role == (int)RoleEnum.Manager))
            {
                ModelState.AddModelError(string.Empty, "You do not have permision to do this function");
                return Page();
            }
            else if (role == -1)
            {
                ModelState.AddModelError(string.Empty, "Wrong password or email");
                return Page();
            }
            HttpContext.Session.SetInt32("role", role ?? -1);
            return RedirectToPage("/art/index");
        }
    }
}
}
