﻿namespace AccessControlProject.Interfaces
{
    public interface IPersonDto
    {
        public bool IsAdmin { get; }
        public string Login { get; }
        public string Password { get; }
        public bool IsBlocked { get; }
    }
}
