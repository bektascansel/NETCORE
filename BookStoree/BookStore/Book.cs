﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore
{

    public class Book
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }



    }



}