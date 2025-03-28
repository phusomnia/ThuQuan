using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1.FakeModels
{
    public class VatDung
    {
        [Required(ErrorMessage = "Id khong duoc de trong")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ten vat dung khong duoc de trong")]
        public string TenVatDung { get; set; }
    }
}