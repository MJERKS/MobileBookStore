using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileBookStore.Model.Entities;

namespace MobileBookStore.ViewModels
{
    public class PreviewViewModel
    {
        public Book Book { get; set; }
        public List<string> PrevImages { get; set; }
        //public string RootPath { get; set; }

        public PreviewViewModel(Book book, List<string> prevImages, string folderName)
        {
            Book = book;
            PrevImages = new List<string>();
            foreach (var image in prevImages)
            {
                PrevImages.Add("../../" + folderName + image);
            }
        }
    }
}