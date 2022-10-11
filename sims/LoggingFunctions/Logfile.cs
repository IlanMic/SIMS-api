namespace sims.LoggingFunctions
{
    public struct Logfile
    {
        public string Protocol = "";
        public string Method = "";
        public string Path = "";

        public Logfile(string protocol, string method, string path)
        {
            Protocol = protocol;
            Method = method;
            Path = path;
        }
    }
    public class LogSaver
    {
        Logfile log;

        public void SavetoDB()
        {
            Console.WriteLine("Test");
        }

    }
}
