﻿using System;
using Xamarin.Forms;

namespace AppProgramming.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        
        public string Date { get; set; }
        
        public string Time { get; set; }
        public string Description { get; set; }
        
        public bool Completed { get; set; }

    }
}