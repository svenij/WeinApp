using SQLite;
using System;

namespace WeinApp.Models
{
    public class UniqueItem
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
