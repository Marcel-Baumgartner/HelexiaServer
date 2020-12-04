using HelexiaNetwork.Network.Packages;

namespace HelexiaServer.Interface
{
    public class Ping_Request : BasePackage
    {
        public string ip;
        public string programm;

        public Ping_Request(string _ip, string _programm)
        {
            ip = _ip;
            programm = _programm;
        }
        public Ping_Request(Package package)
        {
            ip = package.ReadString();
            programm = package.ReadString();
        }
        public Package GetPackage()
        {
            Package package = new Package();

            package.WriteString(ip);
            package.WriteString(programm);

            return package;
        }
    }
}
