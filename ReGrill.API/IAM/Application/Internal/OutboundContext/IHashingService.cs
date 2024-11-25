﻿namespace ReGrill.API.IAM.Application.Internal.OutboundContext;

public interface IHashingService
{
    string CreateSalt();

    string HashCode
        (string code, string salt);

    public bool VerifyHash(string code, string salt, string hash);
}