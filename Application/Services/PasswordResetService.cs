using Application.Common.Interfaces.Repository;
using Domain.Entities;
using System;
using System.Net.Mail;

namespace Domain.Services
{
    public class PasswordResetService
    {
        private readonly string _smtpServer = "smtp.gmail.com"; // SMTP server adresi
        private readonly string _smtpUser = "no.reply.nebula.team@gmail.com"; // SMTP kullanıcı adı
        private readonly string _smtpPass = "uwxmtktukohxdtrl"; // SMTP şifresi

        private readonly IUserRepository _userRepository;
        private readonly IResetCodeRepository _resetCodeRepository;

        public PasswordResetService(IUserRepository userRepository, IResetCodeRepository resetCodeRepository)
        {
            _userRepository = userRepository;
            _resetCodeRepository = resetCodeRepository;
        }

        public async Task RequestPasswordResetAsync(string email)
        {
            var resetCode = GenerateResetCode();
            var user = await GetUserByEmailAsync(email); 
            if (user != null)
            {
                await SaveResetCodeAsync(user.Id, resetCode); 
                SendResetCodeEmail(email, resetCode); 
            }
        }

        private string GenerateResetCode()
        {
            var rng = new Random();
            return rng.Next(100, 999).ToString(); 
        }

        public void SendResetCodeEmail(string email, string resetCode)
        {
            try
            {
                using (var client = new SmtpClient(_smtpServer))
                {
                    client.Port = 587; 
                    client.Credentials = new System.Net.NetworkCredential(_smtpUser, _smtpPass);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_smtpUser),
                        Subject = "Şifre Sıfırlama Kodu",
                        Body = $"Şifre sıfırlama kodunuz: {resetCode}",
                        IsBodyHtml = false,
                    };
                    mailMessage.To.Add(email);

                    client.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"E-posta gönderim hatası: {ex.Message}");
            }
        

    }

        private async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        private async Task SaveResetCodeAsync(Guid userId, string resetCode)
        {
            var resetCodeEntity = new ResetPassword
            {
                UserId = userId,
                ResetCode = resetCode,
                ExpiryDate = DateTime.UtcNow.AddHours(1) 
            };

            await _resetCodeRepository.SaveResetPasswordAsync(resetCodeEntity);
        }

        public async Task<bool> ValidateResetCodeAsync(Guid userId, string resetCode)
        {
            var resetCodeEntity = await _resetCodeRepository.GetResetPasswordByCodeAsync(resetCode);

            if (resetCodeEntity == null || resetCodeEntity.UserId != userId)
            {
                return false;
            }

            return !IsResetCodeExpired(resetCodeEntity); 
        }

        public async Task ChangePasswordAsync(Guid userId, string newPassword)
        {
          
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("Kullanıcı bulunamadı");
            }

            user.Password = newPassword; 

            await _userRepository.UpdateAsync(user);
        }

        private bool IsResetCodeExpired(ResetPassword resetCode)
        {
            return DateTime.UtcNow > resetCode.ExpiryDate;
        }
    }
}
