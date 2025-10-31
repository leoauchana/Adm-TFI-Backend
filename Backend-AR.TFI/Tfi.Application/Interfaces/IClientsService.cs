﻿using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IClientsService
{
    Task<List<ClientDto.Response>?> GetAll();
}
