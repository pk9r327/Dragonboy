namespace QLTK.Models
{
    public class NroServer
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public int Language { get; set; }

        public NroServer() { }

        public NroServer(string name, string ip, int port, int language)
        {
            this.Name = name;
            this.Ip = ip;
            this.Port = port;
            this.Language = language;
        }

        public NroServer(string name, string ip, int port)
        {
            this.Name = name;
            this.Ip = ip;
            this.Port = port;
            this.Language = 0;
        }
    }
}
