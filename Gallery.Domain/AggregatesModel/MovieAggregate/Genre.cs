using Gallery.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery.Domain.AggregatesModel.MovieAggregate
{
    public class Genre : ValueObject
    {
        //public int Id { get; private set; }
        //public string Name { get; private set; }

        //public Genre(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
