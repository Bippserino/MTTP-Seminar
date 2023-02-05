using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mttpp_seminar
{
    class Product
    {
        public string Title { get; private set; }
        public string Price { get; private set; }

        public Product(string title, string price)
        {
            Title = title;
            Price = price;
        }
    }
}
