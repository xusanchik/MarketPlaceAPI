﻿namespace MarketPlace.Entityes
{
    public class AuditableEntity
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string Action { get; set; }
        public string Path { get; set; }
        public int ResponseStatusCode { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ResponseTimestamp { get; set; }
    }
}
