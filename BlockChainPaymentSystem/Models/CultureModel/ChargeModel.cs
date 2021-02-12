using System.ComponentModel.DataAnnotations;

namespace BlockChainPaymentSystem.Models.CultureModel
{
    public class ChargeModel
    {
        public int src10Id { get; set; }
        public int src20Id { get; set; }
        public int src30Id { get; set; }
        public int src40Id { get; set; }

        public int accid { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src11 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src12 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src13 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "4~6자리 수를 입력하세요.")]
        [Display(Name = "4자리 또는 6자리 숫자")]
        public string src14 { get; set; }


        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src21 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src22 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src23 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "4~6자리 수를 입력하세요.")]
        [Display(Name = "4자리 또는 6자리 숫자")]
        public string src24 { get; set; }


        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src31 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src32 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src33 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "4~6자리 수를 입력하세요.")]
        [Display(Name = "4자리 또는 6자리 숫자")]
        public string src34 { get; set; }


        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src41 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src42 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "4자리 수를 입력하세요.")]
        [Display(Name = "4자리 숫자")]
        public string src43 { get; set; }

        [Required(ErrorMessage = "번호를 확인해주세요.")]
        [StringLength(6, MinimumLength = 4, ErrorMessage = "4~6자리 수를 입력하세요.")]
        [Display(Name = "4자리 또는 6자리 숫자")]
        public string src44 { get; set; }
    }

}
