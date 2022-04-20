using System.ComponentModel.DataAnnotations;

namespace CaseItau.API.Helper.CustomAttributes
{
    public class CnpjValidationAttribute : ValidationAttribute
    {
        public CnpjValidationAttribute()
        {

        }
        public override bool IsValid(object value)
        {
            return IsCnpj(value.ToString());
        }
        private bool IsCnpj(string cnpj)
        {
            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];

            int renmant = (sum % 11);
            if (renmant < 2)
                renmant = 0;
            else
                renmant = 11 - renmant;

            string digit = renmant.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];

            renmant = (sum % 11);
            if (renmant < 2)
                renmant = 0;
            else
                renmant = 11 - renmant;

            digit = digit + renmant.ToString();

            return cnpj.EndsWith(digit);
        }
    }
}
