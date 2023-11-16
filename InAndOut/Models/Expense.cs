using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense Name")]
        [Required]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1, int.MaxValue,ErrorMessage ="Amount Must be Greater than 0")]
        public double Amount { get; set; }
        [DisplayName("Expense Type")]
        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }
}
