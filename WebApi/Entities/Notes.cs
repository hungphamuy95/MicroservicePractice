using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Entities
{
    public class Notes : BaseEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string ImageUrl { get; set; }

        public string SeoUrl { get; set; }
    }
}
