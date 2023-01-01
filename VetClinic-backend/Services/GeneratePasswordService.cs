using VetClinic_backend.Interfaces;

namespace VetClinic_backend.Services
{
    public class GeneratePasswordService: IGeneratePassword
    {
        public string GenerateRandomCode() 
        {
            Guid g = Guid.NewGuid();
            string stringCode = Convert.ToBase64String(g.ToByteArray());
            return stringCode.Replace("=", "").
                Replace("/", "").
                Replace("+", "").
                Substring(0,10);
        }
    }
}
