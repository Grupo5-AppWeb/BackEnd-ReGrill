﻿namespace ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Administration;

public record AdministratorResource(int Id, string Username, string Email, string Name, string PhoneNumber, string Surname);