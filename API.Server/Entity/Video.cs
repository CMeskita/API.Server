namespace API.Server.Entity
{
    public class Video
    {
        public Video()
        {
                
        }
        public Video(string name, string url, int servidorid)
        {
            Name = name;
            Url = url;
            Register = DateTime.Now.ToString("dd-MM-y");
            ServidorId = servidorid;

        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Url { get; protected set; }
        public string Register { get; protected set; }
        public int ServidorId { get; set; }
        public virtual Servidor Servidor { get; protected set; }
    }
}
