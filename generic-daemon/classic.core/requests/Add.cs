namespace classic.core.requests
{
    public class Add : Request
    {
        public Add() => Name = string.Empty;

        public string Name { get; set; }
    }
}