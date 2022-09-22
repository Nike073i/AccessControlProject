namespace AccessControlProject.Interfaces
{
    public interface IPersonDto
    {
        public bool IsAdmin();
        public string Login { get; }
        public string Password { get; }
        public bool IsBlocked { get; }
        public bool IsLimited { get; }
    }
}
