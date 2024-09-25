using ReportBook.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportBook.Domain.Entity
{
    public class UserEntity : IAuditable, IEntityId<long>
    {
        public long Id { get; set; }

        public string? Loggin { get; set; }

        public string? Password { get; set; }

        public List<ReportEntity>? Reports { get; set; }

        public DateTime CreatedAt { get; set; }

        public long CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public long UpdatedBy { get; set; }
    }
}
