﻿namespace Skunkworks.Shared;

public class LoggedInUser
{
    public Guid Id { get; set; }
    public string Email { get; set; }=string.Empty;
    public string[] Roles { get; set; } = [];
}
