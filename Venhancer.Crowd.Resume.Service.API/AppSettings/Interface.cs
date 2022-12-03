namespace Venhancer.Crowd.Resume.Service.API.AppSettings
{
    public interface IDatabaseSettings
    {
        public string ResumeCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DBName { get; set; }
    }
}
