using Microsoft.AspNetCore.Mvc.Rendering;

namespace InAndOut.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }
        public IEnumerable<SelectListItem> ExpenseTypesList { get; set; }
    }
}
