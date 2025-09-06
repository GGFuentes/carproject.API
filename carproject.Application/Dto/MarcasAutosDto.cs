﻿namespace carproject.Application.Dto
{
    public class MarcasAutosDto
    {
        public int Id { get; set; }

        public string Brand { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int Year { get; set; }

        public decimal Price { get; set; }

    }
}
