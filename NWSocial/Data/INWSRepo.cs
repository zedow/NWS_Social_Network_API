﻿using NWSocial.Dtos;
using NWSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWSocial.Data
{
    public interface INWSRepo
    {
        bool SaveChanges();
        IEnumerable<Guild> GetAllGuilds();
        Guild GetGuildById(int id);
        void CreateGuild(Guild guild);
        void UpdateGuild(Guild guild);
        void DeleteGuild(Guild guild);
        void AddUserGuild(UserGuild userGuild);

        User GetUserById(int id);

        // UserGuilds Relation
        IEnumerable<User> GetGuildUsers(int idGuild);
        IEnumerable<Guild> GetUserGuilds(int idUser);
    }
}