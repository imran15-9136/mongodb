using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Server.Model
{
    [BsonIgnoreExtraElements]
    public class Comments
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("movie_id")]
        public ObjectId MovieId { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
        //[BsonExtraElements]
        //public object[] Bucket { get; set; }
    }
}
