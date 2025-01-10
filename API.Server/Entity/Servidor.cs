namespace API.Server.Entity
{
    public class Servidor
    {
        public Servidor( string name, string ipAdress, string description)
        {
            Name = name;
            IpAdress = ipAdress;
            Description = description;
        }

        public int Id { get;protected set; }
        public string Name { get; protected set; }
        public string IpAdress { get; protected set; }
        public string Description { get; protected set; }
        public virtual IList<Video> Videos { get; protected set; }
    }
}
