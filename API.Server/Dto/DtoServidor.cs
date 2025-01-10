using API.Server.Entity;
using System.Text.Json.Serialization;

namespace API.Server.Dto
{
    public class DtoServidor
    {
        public DtoServidor(string name, string ipAdress, string description)
        {
            Name = name;
            IpAdress = ipAdress;
            Description = description;
        }

        public string Name { get; set; }
        public string IpAdress { get; set; }
        public string Description { get; set; }

        public static implicit operator Servidor(DtoServidor dto)
       => new Servidor(dto.Name, dto.IpAdress,dto.Description);

    }
    public class DtoVideo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        [JsonIgnore]
        public int ServidorId { get; set; }
       
        public static implicit operator Video(DtoVideo dto)
       => new Video(dto.Name, dto.Url, dto.ServidorId);
    }
    public class DtoVideoListResponse
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Url { get;  set; }
        public string Register { get;  set; }

        public virtual List<Video> VideoList { get; set; }
    }

}
