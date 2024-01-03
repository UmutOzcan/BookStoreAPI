﻿namespace WebApi.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}