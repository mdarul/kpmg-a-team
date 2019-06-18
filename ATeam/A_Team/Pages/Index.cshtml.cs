using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A_Team.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Rules.RunRules();
        }
    }
}
