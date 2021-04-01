using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Igreja.Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
