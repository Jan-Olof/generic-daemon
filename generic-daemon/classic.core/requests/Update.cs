using System;

namespace classic.core.requests
{
    public class Update : Request
    {
        public Update() => Name = string.Empty;

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}