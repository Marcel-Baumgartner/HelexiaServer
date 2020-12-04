using HelexiaNetwork.Network.Packages;

namespace HelexiaServer.Interface
{
    public class Ping_Response : BasePackage
    {
        public string serverString;
        public int version;

        public Ping_Response(string _serverString, int _version)
        {
            serverString = _serverString;
            version = _version;
        }
        public Ping_Response(Package package)
        {
            serverString = package.ReadString();
            version = package.ReadInt();
        }
        public Package GetPackage()
        {
            Package package = new Package();

            package.WriteString(serverString);
            package.WriteInt(version);

            return package;
        }
    }
}
