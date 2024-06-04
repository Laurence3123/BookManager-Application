﻿namespace BookManager.Models
{
    public class Study
    {
        public int StudyId { get; set; }
        public string? AuthorName { get; set; }
        public string? Univer { get; set; }
        public string? Course { get; set; }
        public decimal CCost { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
