using System;

namespace classic.core.requests
{
    public class Add : Request
    {
        public Add() => Name = string.Empty;

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}