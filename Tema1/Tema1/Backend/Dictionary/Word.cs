﻿namespace Dictionar.Backend
{
    public class Word
    {
        public string Name {  get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public Word() 
        {
            Name = "None";
            Description = "None";
            Category = "None";
            Image = "C:\\Gabi\\Mvp\\MVP\\Tema1\\Tema1\\Resources\\Images\\NoImage.jpg";
        }

        public Word(string name, string category, string description)
        {
            Name = name;
            Category = category;
            Description = description;
            Image = "C:\\Gabi\\Mvp\\MVP\\Tema1\\Tema1\\Resources\\Images\\NoImage.jpg";
        }

        public Word(string name, string category, string description, string image)
        {
            Name = name;
            Category = category;
            Description = description;
            Image = image;
        }
    }
}
