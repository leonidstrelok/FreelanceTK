using System.IO;

namespace FreelanceTK.Application.Common.Models
{
    /// <summary>
    /// Вложения для сообщения
    /// </summary>
    public class EmailAttachments
    {
        public string Name { get; set; }
        public Stream Data { get; set; }
    }
}
